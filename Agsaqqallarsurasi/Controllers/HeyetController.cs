using Agsaqqallarsurasi.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class HeyetController : Controller
    {
        private readonly AppDbContext _context;

        public HeyetController(AppDbContext context)
        {
            _context = context;
        }

        // GET: RayonSedrController
        public async Task<ActionResult> Index()
        {

            return View(await _context.IdareHeyeti.ToListAsync());
        }

        // GET: HeyetController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

     
    }
}
