using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agsaqqallarsurasi.Controllers
{
    public class HeyetController : Controller
    {
        // GET: HeyetController
        public ActionResult Index()
        {
            return View();
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
