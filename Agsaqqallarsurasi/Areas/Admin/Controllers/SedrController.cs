using Agsaqqallarsurasi.Areas.Admin.ViewModels;
using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Agsaqqallarsurasi.Utilities.Constants;
using Agsaqqallarsurasi.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers
{
	[Area("Admin")]
    //[Authorize(Roles = "Admin")]
    [Authorize]

    public class SedrController : Controller
	{
		private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public SedrController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: SedrController
        public async Task<ActionResult> Index()
		{
			List<Sedr> sedrs = await _appDbContext.Sedr.OrderByDescending(p => p.Id).ToListAsync();
			return View(sedrs);
		}
        public async Task<IActionResult> Create()
        {
            CreateSedrVM createSedrVM = new CreateSedrVM();
            return View(createSedrVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateSedrVM createSedr)
        {
            if (!ModelState.IsValid) { return View(createSedr); }
            if (!createSedr.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(createSedr); }
            if (!createSedr.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(createSedr); }
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
            string fileName = await createSedr.Photo.SaveAsync(rootPath);
            Sedr sedr = new Sedr
            {
                Description = createSedr.Description,
                FullName = createSedr.FullName,
                ImagePath = fileName,

            };
            await _appDbContext.Sedr.AddAsync(sedr);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            Sedr sedr = await _appDbContext.Sedr.FindAsync(id);
            if (sedr == null) return NotFound();
            string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs", sedr.ImagePath);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);

            }
            _appDbContext.Sedr.Remove(sedr);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Update(int id)
        {
            Sedr sedr = await _appDbContext.Sedr.FindAsync(id);
            if (sedr == null) return NotFound();
            UpdateSedrVM updateSedr = new UpdateSedrVM()
            {
                Description = sedr.Description,
                FullName = sedr.FullName,
                Id = id

            };
            return View(updateSedr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateSedrVM update)
        {
            if (!ModelState.IsValid) return View(update);
            if (!update.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(update); }
            if (!update.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(update); }



            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
            Sedr sedr = await _appDbContext.Sedr.FindAsync(update.Id);
            string filepath = Path.Combine(rootPath, sedr.ImagePath);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);

            }
            string newFileName = await update.Photo.SaveAsync(rootPath);


            sedr.Id = update.Id;
            sedr.FullName = update.FullName;
            sedr.Description = update.Description;
            sedr.ImagePath = newFileName;

            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
