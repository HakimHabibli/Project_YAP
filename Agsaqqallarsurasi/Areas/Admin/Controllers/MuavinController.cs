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


        public async Task<IActionResult> Create()
        {
            CreateMuavinVM create = new CreateMuavinVM();

            return View(create);
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
        


        public async Task<ActionResult> Delete(int id)
        {
            Muavin muavin = await _context.Muavins.FindAsync(id);
            if (muavin == null) return NotFound();
            string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs", muavin.ImagePath);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);

            }
            _context.Muavins.Remove(muavin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int id)
        {
            Muavin muavin = await _context.Muavins.FindAsync(id);
            if (muavin == null) return NotFound();
            UpdateMuavinVM updateMuavinVM = new UpdateMuavinVM()
            {
               Description = muavin.Description,
               Title = muavin.Title,
                Id=id
            };

            return View(updateMuavinVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateMuavinVM update)
        {
            if (!ModelState.IsValid) return View(update);
            if (!update.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(update); }
            if (!update.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(update); }


            
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
            Muavin muavin = await _context.Muavins.FindAsync(update.Id);
            string filepath = Path.Combine(rootPath, muavin.ImagePath);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);

            }
            string newFileName = await update.Photo.SaveAsync(rootPath);


            muavin.Id = update.Id;
            muavin.Title = update.Title;
            muavin.Description = update.Description;
            muavin.ImagePath = newFileName;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }

   
}
