using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class SedrController : Controller
    {
        private readonly AppDbContext _context;

        public SedrController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SedrController
        public async Task<ActionResult> Index()
        {
            
            return View(await _context.Sedr.ToListAsync());
        }

        // GET: SedrController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

       
    }
}
