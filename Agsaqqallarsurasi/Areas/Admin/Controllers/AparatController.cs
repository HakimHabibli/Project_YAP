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
    //[Authorize(Roles ="Admin")]
    [Authorize]

    public class AparatController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AparatController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: AparatController
        public async Task<ActionResult> Index()
        {
            List<Aparat> aparats = await _context.Aparat.OrderByDescending(p=>p.Id).ToListAsync();
            return View(aparats);

		}

        public async Task<IActionResult> Create()
        {
            CreateAparatVM createAparatVM = new CreateAparatVM();

            return View(createAparatVM);
        }

        // POST: AparatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAparatVM aparatVM) 
        {
            if(!ModelState.IsValid)return View(aparatVM);
            if (!aparatVM.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(aparatVM); }
            if (!aparatVM.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(aparatVM); }
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
            string fileName = await aparatVM.Photo.SaveAsync(rootPath);
            
            Aparat aparat = new Aparat 
            {
            Title=aparatVM.Title,
            FullName=aparatVM.FullName,
            DateTime = aparatVM.DateTime,
            
            Description=aparatVM.Description,
            ImagePath = fileName
            };
            await _context.Aparat.AddAsync(aparat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }
        // GET: AparatController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Aparat aparat = await _context.Aparat.FindAsync(id);
            if (aparat == null) return NotFound();
            string filepath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs", aparat.ImagePath);
            if (System.IO.File.Exists(filepath)) 
            {
                System.IO.File.Delete(filepath);

            }
            _context.Aparat.Remove(aparat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int id) 
        {
            Aparat aparat = await _context.Aparat.FindAsync(id);
            if (aparat == null) return NotFound();
            UpdateAparatVM updateAparatVM = new UpdateAparatVM() 
            {
                Description = aparat.Description,
                DateTime = aparat.DateTime,
                FullName = aparat.FullName,
                Id = id,
                Title = aparat.Title,
                
            };

            return View(updateAparatVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateAparatVM updateAparatVM) 
        {
            if (!ModelState.IsValid) return View(updateAparatVM);
            if (!updateAparatVM.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(updateAparatVM); }
            if (!updateAparatVM.Photo.CheckFileSize(20480)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe20MB); return View(updateAparatVM); }
            
            
            //string oldFilename = (await _context.Aparat.FindAsync(updateAparatVM.Id))?.ImagePath; 
            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
            Aparat aparat = await _context.Aparat.FindAsync(updateAparatVM.Id);
            string filepath = Path.Combine(rootPath, aparat.ImagePath);
            if (System.IO.File.Exists(filepath))
            {
                System.IO.File.Delete(filepath);

            }
            string newFileName = await updateAparatVM.Photo.SaveAsync(rootPath);


                aparat.Id = updateAparatVM.Id;
                aparat.Title = updateAparatVM.Title;
                aparat.FullName = updateAparatVM.FullName;
                aparat.DateTime = updateAparatVM.DateTime;
                aparat.Description = updateAparatVM.Description;
                aparat.ImagePath = newFileName;
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
