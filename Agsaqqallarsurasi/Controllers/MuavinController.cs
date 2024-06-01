        using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class MuavinController : Controller
    {
        private readonly AppDbContext _context;


        public MuavinController(AppDbContext context)
        {
            _context = context;
        }

        // GET: MuavinController
        public async Task<ActionResult> Index()
        {

            return View(await _context.Muavins.ToListAsync());
        }
     

        // GET: MuavinController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var muavin = await _context.Muavins.FindAsync(id);
            if (muavin == null)
            {
                return NotFound();
            }
            return View(muavin);

        }

     
    }
}
