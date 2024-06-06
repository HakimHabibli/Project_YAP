using Agsaqqallarsurasi.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class CongratsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CongratsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: CongratsController
        public async Task<ActionResult> Index()
        {
            return View(await _appDbContext.Congrats.ToListAsync());
        }

        // GET: CongratsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var congrats = await _appDbContext.Congrats.FirstOrDefaultAsync(s => s.Id ==id);
            if(congrats==null)return NotFound();
            return View(congrats);
        }

    }
}
