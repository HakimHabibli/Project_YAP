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

		// GET: KomissiyaController/Create
		public ActionResult Create()
        {
            return View();
        }

        // POST: KomissiyaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KomissiyaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: KomissiyaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: KomissiyaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: KomissiyaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
