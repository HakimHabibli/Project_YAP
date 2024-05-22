using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agsaqqallarsurasi.Controllers
{
    public class DetailController : Controller
    {
        // GET: DetailController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DetailController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DetailController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DetailController/Create
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

        // GET: DetailController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DetailController/Edit/5
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

        // GET: DetailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DetailController/Delete/5
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
