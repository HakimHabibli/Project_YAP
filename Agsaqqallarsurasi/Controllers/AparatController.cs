using Agsaqqallarsurasi.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class AparatController : Controller
    {
        private readonly AppDbContext _context;


        public AparatController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AparatController
        public async Task<ActionResult> Index()
        {

            return View(await _context.Aparat.ToListAsync());
        }


        // GET: AparatController/Details/
        public async Task<ActionResult> Details(int id)
        {
            var aparat = await _context.Aparat.FindAsync(id);
            if (aparat == null)
            {
                return NotFound();
            }
            return View(aparat);

        }

       
    }
}
