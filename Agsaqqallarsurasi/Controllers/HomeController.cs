using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Agsaqqallarsurasi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Agsaqqallarsurasi.Controllers
{
    public class HomeController : Controller
    {
       private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM  homeVM = new() 
            {
             Congrats = await _appDbContext.Congrats.OrderByDescending(x => x.Id).ToListAsync(),
             News=await _appDbContext.News.OrderByDescending(x => x.Id).Include(s=>s.NewsImages).ToListAsync()
            };
            return View(homeVM);
        }

        
    
    }
}
