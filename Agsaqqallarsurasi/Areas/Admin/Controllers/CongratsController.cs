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
	[Authorize]
	public class CongratsController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public CongratsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
		{
			_context = context;
			_webHostEnvironment = webHostEnvironment;
		}

		// GET: NezaretKomissiyasiController
		public async Task<ActionResult> Index()
		{
			List<Congrats> congrats = await _context.Congrats.OrderByDescending(x=>x.Id).ToListAsync();
			return View(congrats);
		}

		public async Task<IActionResult> Create()
		{
			CreateCongratsVM createCongrats = new CreateCongratsVM();

			return View(createCongrats);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(CreateCongratsVM createCongrats)
		{
			if (!ModelState.IsValid) { return View(createCongrats); }
			if (!createCongrats.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(createCongrats); }
			if (!createCongrats.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(createCongrats); }
			string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
			string fileName = await createCongrats.Photo.SaveAsync(rootPath);
			Congrats congrats = new Congrats
			{
				Description = createCongrats.Description,
				DateTime = createCongrats.DateTime,
				FullName = createCongrats.FullName,
				Age = createCongrats.Age,
				ImagePath = fileName,

			};
			await _context.Congrats.AddAsync(congrats);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		public async Task<ActionResult> Delete(int id)
		{
			Congrats congrats = await _context.Congrats.FindAsync(id);
			if (congrats == null) return NotFound();
			string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs", congrats.ImagePath);
			if (System.IO.File.Exists(filepath))
			{
				System.IO.File.Delete(filepath);

			}
			_context.Congrats.Remove(congrats);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}

		public async Task<IActionResult> Update(int id)
		{
			Congrats congrats = await _context.Congrats.FindAsync(id);
			if (congrats == null) return NotFound();
			UpdateCongratsVM updateCongrats = new UpdateCongratsVM()
			{
				Id = id,
				DateTime = congrats.DateTime,
				Description = congrats.Description,
				FullName = congrats.FullName,
				Age = congrats.Age,
			};
			return View(updateCongrats);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Update(UpdateCongratsVM update)
		{
			if (!ModelState.IsValid) return View(update);
			if (!update.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(update); }
			if (!update.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(update); }
			string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");

			Congrats congrats = await _context.Congrats.FindAsync(update.Id);
			string filepath = Path.Combine(rootPath, congrats.ImagePath);
			if (System.IO.File.Exists(filepath))
			{
				System.IO.File.Delete(filepath);

			}
			string newFileName = await update.Photo.SaveAsync(rootPath);


			
			congrats.FullName = update.FullName;
			congrats.DateTime = update.DateTime;
			congrats.Description = update.Description;
			congrats.Age = update.Age;
			congrats.ImagePath = newFileName;

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}
	}
}
