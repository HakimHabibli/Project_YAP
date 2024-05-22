using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agsaqqallarsurasi.Controllers
{
    public class RayonController : Controller
    {
        // GET: RayonController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RayonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RayonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RayonController/Create
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

        // GET: RayonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RayonController/Edit/5
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

        // GET: RayonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RayonController/Delete/5
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
