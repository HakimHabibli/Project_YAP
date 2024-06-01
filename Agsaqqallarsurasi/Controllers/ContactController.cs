using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agsaqqallarsurasi.Controllers
{
    public class ContactController : Controller
    {
        // GET: ContactController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      
    }
}
