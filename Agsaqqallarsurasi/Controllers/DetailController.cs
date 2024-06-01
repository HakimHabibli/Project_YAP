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

    }
}
