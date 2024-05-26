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

        // GET: HeyetController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HeyetController/Create
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

        // GET: HeyetController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HeyetController/Edit/5
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

        // GET: HeyetController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HeyetController/Delete/5
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
