using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agsaqqallarsurasi.Controllers
{
    public class AparatController : Controller
    {
        // GET: AparatController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AparatController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
