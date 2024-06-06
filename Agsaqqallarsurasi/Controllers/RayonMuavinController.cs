using Agsaqqallarsurasi.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class RayonMuavinController : Controller
    {
        private readonly AppDbContext _context;

        public RayonMuavinController(AppDbContext context)
        {
            _context = context;
        }
        // GET: RayonMuavinController
        public async Task<ActionResult> Index()
        {
            return View(await _context.RayonMuavins.ToListAsync());
        }

        // GET: RayonMuavinController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var rayonMuavin = await _context.RayonMuavins.FindAsync(id);
            if (rayonMuavin==null) 
            {
                return NotFound();
            }
            return View(rayonMuavin);
        }

    }
}
