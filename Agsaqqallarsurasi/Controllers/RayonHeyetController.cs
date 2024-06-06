using Agsaqqallarsurasi.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class RayonHeyetController : Controller
    {
        private readonly AppDbContext _context;

        public RayonHeyetController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.RayonHeyets.ToListAsync());
        }
    }
}
