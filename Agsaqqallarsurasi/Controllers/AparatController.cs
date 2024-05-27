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

        // GET: AparatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AparatController/Create
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

        // GET: AparatController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AparatController/Edit/5
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

        // GET: AparatController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AparatController/Delete/5
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
