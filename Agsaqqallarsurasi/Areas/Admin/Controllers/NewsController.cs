using Agsaqqallarsurasi.Areas.Admin.ViewModels;
using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Agsaqqallarsurasi.Utilities.Constants;
using Agsaqqallarsurasi.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers;
[Area("Admin")]

public class NewsController : Controller
{
    private readonly AppDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public NewsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
    {
        _context = context;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        List<News> news = await _context.News
           .Where(s => !s.IsDeleted)
           .OrderByDescending(s => s.Id)
           .Take(8)
           .Include(s => s.NewsImages)
           .ToListAsync();

        return View(news);
    }

    public async Task<IActionResult> Create()
    {
        CreateNewsVM createnewsVM = new CreateNewsVM();

        return View(createnewsVM);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateNewsVM createNewsVM)
    {
        if (!ModelState.IsValid) return View();
        foreach (var photo in createNewsVM.Photos)
        {
            if (!photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photos", $"{photo.FileName} - {Messages.FileTypeMustBeImage}");
                return View();
            }
            if (!photo.CheckFileSize(20480))
            {
                ModelState.AddModelError("Photos", $"{photo.FileName} - {Messages.FileSizeMustBe20MB}");
                return View();
            }
        }
        List<NewsImage> images = new List<NewsImage>();
        foreach (var photo in createNewsVM.Photos)
        {
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
            string fileName = await photo.SaveAsync(rootPath);
            NewsImage image = new NewsImage()
            {
                Path = fileName
            };
            if (!images.Any(i => i.IsActive))
            {
                image.IsActive = true;
            }
            images.Add(image);
        }
        News news = new News()
        {
            Title = createNewsVM.Title,
            Description = createNewsVM.Description,
            DateTime = createNewsVM.DateTime,
            NewsImages = images,
        };
        await _context.News.AddAsync(news);
        await _context.SaveChangesAsync();
        return View(createNewsVM);
    }


}
