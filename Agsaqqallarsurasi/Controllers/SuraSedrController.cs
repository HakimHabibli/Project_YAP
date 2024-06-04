using Agsaqqallarsurasi.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class SuraSedrController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SuraSedrController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // GET: SuraSedrController
        public async Task<ActionResult> Index()
        {
            return View(await _appDbContext.SuraSedr.ToListAsync());

        }

        // GET: SuraSedrController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      
    }
}
