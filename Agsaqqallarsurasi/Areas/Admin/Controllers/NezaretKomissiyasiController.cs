using Agsaqqallarsurasi.Areas.Admin.ViewModels;
using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Agsaqqallarsurasi.Utilities.Constants;
using Agsaqqallarsurasi.Utilities.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers
{
	[Area("Admin")]
    //[Authorize(Roles = "Admin")]
    [Authorize]


    public class NezaretKomissiyasiController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

        public NezaretKomissiyasiController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }   

        // GET: NezaretKomissiyasiController
        public async Task<ActionResult> Index()
		{
			List<NezaretKomissiyasi> nezaretKomissiyasis = await _context.NezaretKomissiyasi.OrderByDescending(p=>p.Id).ToListAsync();
			return View(nezaretKomissiyasis);
		}

        public async Task<IActionResult> Create()
        {
            CreateNezaretKomissiyasiVM createNezaret = new CreateNezaretKomissiyasiVM();

            return View(createNezaret);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateNezaretKomissiyasiVM createNezaret)
        {
            if (!ModelState.IsValid) { return View(createNezaret); }
            if (!createNezaret.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(createNezaret); }
            if (!createNezaret.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(createNezaret); }
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
            string fileName = await createNezaret.Photo.SaveAsync(rootPath);
            NezaretKomissiyasi nezaret = new NezaretKomissiyasi
            {
                Description = createNezaret.Description,
                DateTime = createNezaret.DateTime,
                FullName = createNezaret.FullName,
                Position = createNezaret.Position,
                ImagePath = fileName,

            };
            await _context.NezaretKomissiyasi.AddAsync(nezaret);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Delete(int id)
        {
            NezaretKomissiyasi nezaret = await _context.NezaretKomissiyasi.FindAsync(id);
            if (nezaret == null) return NotFound();
            string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs", nezaret.ImagePath);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);

            }
            _context.NezaretKomissiyasi.Remove(nezaret);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int id)
        {
            NezaretKomissiyasi nezaret = await _context.NezaretKomissiyasi.FindAsync(id);
            if (nezaret == null) return NotFound();
            UpdateNezaretKomissiyasiVM updateNezaret = new UpdateNezaretKomissiyasiVM()
            {
               DateTime = nezaret.DateTime,
               Description =nezaret.Description,
               FullName = nezaret.FullName,
               Position = nezaret.Position,
               Id = id

            };
            return View(updateNezaret);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateNezaretKomissiyasiVM update)
        {
            if (!ModelState.IsValid) return View(update);
            if (!update.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(update); }
            if (!update.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(update); }
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");

            NezaretKomissiyasi nezaret = await _context.NezaretKomissiyasi.FindAsync(update.Id);
            string filepath = Path.Combine(rootPath, nezaret.ImagePath);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);

            }
            string newFileName = await update.Photo.SaveAsync(rootPath);


            nezaret.Id = update.Id;
            nezaret.FullName = update.FullName;
            nezaret.DateTime = update.DateTime;
            nezaret.Position = update.Position;
            nezaret.Description = update.Description;
            nezaret.ImagePath = newFileName;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
