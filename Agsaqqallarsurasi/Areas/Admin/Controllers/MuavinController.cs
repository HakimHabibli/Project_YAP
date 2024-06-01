using Agsaqqallarsurasi.Areas.Admin.ViewModels;
using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Agsaqqallarsurasi.Utilities.Constants;
using Agsaqqallarsurasi.Utilities.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class MuavinController : Controller
	{
		private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public MuavinController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: MuavinController
        public async Task<ActionResult> Index()
		{
			List<Muavin> muavins = await _context.Muavins.OrderByDescending(p => p.Id).ToListAsync();
			return View(muavins);
		}

	


		[HttpPost]
		[ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateMuavinVM muavinVM)
        {
			if (!ModelState.IsValid) { return View(muavinVM); }
            if (!muavinVM.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(muavinVM); }
            if (!muavinVM.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(muavinVM); }
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
            string fileName = await muavinVM.Photo.SaveAsync(rootPath);
			Muavin muavin = new Muavin
			{
				Title = muavinVM.Title,
				Description = muavinVM.Description,
				ImagePath=fileName
			};
            await _context.Muavins.AddAsync(muavin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

		// GET: MuavinController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: MuavinController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: MuavinController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: MuavinController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}

   
}
