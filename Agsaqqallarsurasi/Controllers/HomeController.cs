using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Agsaqqallarsurasi.Controllers
{
    public class HomeController : Controller
    {
      

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    
    }
}
