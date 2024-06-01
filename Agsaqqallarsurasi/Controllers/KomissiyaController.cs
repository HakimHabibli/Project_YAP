using Agsaqqallarsurasi.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class KomissiyaController : Controller
    {
        private readonly AppDbContext _context;

		public KomissiyaController(AppDbContext context)
		{
			_context = context;
		}

		// GET: KomissiyaController
		public async Task<ActionResult> Index()
        {
            return View(await _context.NezaretKomissiyasi.ToListAsync());
        }

		// GET: KomissiyaController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			var nezaret = await _context.NezaretKomissiyasi.FindAsync(id);
			if (nezaret == null)
			{
				return NotFound();
			}
			return View(nezaret);

		}

		
    }
}
