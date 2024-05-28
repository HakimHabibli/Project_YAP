using Agsaqqallarsurasi.Areas.Admin.Models;
using Agsaqqallarsurasi.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers;
[Area("Admin")]

public class NewsController : Controller
{
    private readonly AppDbContext _context;

    public NewsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View
            (
            await _context.News
            .Where(s => !s.IsDeleted)
            .OrderByDescending(s => s.Id)
            .Take(8)
            .Include(s => s.NewsImages)
            .ToListAsync()
            );
    }
    public async Task<IActionResult> Create()
    {
        CreateNewsVM createnewsVM = new CreateNewsVM();
        return View();
    }
}
