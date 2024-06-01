using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agsaqqallarsurasi.Controllers
{
    public class AboutController : Controller
    {
        // GET: AboutController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AboutController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
