using Agsaqqallarsurasi.Areas.Admin.ViewModels;
using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Agsaqqallarsurasi.Utilities.Constants;
using Agsaqqallarsurasi.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers;
[Area("Admin")]
//[Authorize(Roles = "Admin")]
[Authorize]


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

            NewsImage image = new NewsImage() { Path = fileName};

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
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id) 
    {
        var news = await _context.News
        .Include(n => n.NewsImages)
        .FirstOrDefaultAsync(m => m.Id == id);
        if (news == null)
        {
            return NotFound();
        }

        // Faylları fayl sistemindən silmək
        foreach (var image in news.NewsImages)
        {
            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs", image.Path);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
        }

        _context.News.Remove(news);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    //// GET: News/Delete/5
    //public async Task<IActionResult> Delete(int? id)
    //{
    //    if (id == null)
    //    {
    //        return NotFound();
    //    }

    //    var news = await _context.News
    //        .Include(n => n.NewsImages)
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (news == null)
    //    {
    //        return NotFound();
    //    }

    //    return View(news);
    //}

    //[HttpPost] 
    //[ActionName("Delete")]
    //[ValidateAntiForgeryToken]
    //public async Task<IActionResult> DeleteConfirmed(int id)
    //{
    //    var news = await _context.News
    //        .Include(n => n.NewsImages)
    //        .FirstOrDefaultAsync(m => m.Id == id);
    //    if (news == null)
    //    {
    //        return NotFound();
    //    }

    //    // Faylları fayl sistemindən silmək
    //    foreach (var image in news.NewsImages)
    //    {
    //        var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs", image.Path);
    //        if (System.IO.File.Exists(imagePath))
    //        {
    //            System.IO.File.Delete(imagePath);
    //        }
    //    }

    //    _context.News.Remove(news);
    //    await _context.SaveChangesAsync();
    //    return RedirectToAction(nameof(Index));
    //}


}
