    using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class NewsController : Controller
    {
        // GET: NewsController
        private readonly AppDbContext _appDbContext;

        public NewsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<News> news = await _appDbContext.News
    
            .OrderByDescending(s => s.Id)
            .Take(8)
            .Include(s => s.NewsImages)
            .ToListAsync();

            return View(news);

        }

        // GET: NewsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var news = await _appDbContext.News
        .Include(s => s.NewsImages)
        .FirstOrDefaultAsync(n => n.Id == id);

            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        
    }
}
