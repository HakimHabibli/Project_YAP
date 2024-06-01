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

		// GET: AparatController/Details/5
		public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AparatController/Create
        public  IActionResult Create()
        {
            return View();
        }

        // POST: AparatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateAparatVM aparatVM) 
        {
            if(!ModelState.IsValid)return View(aparatVM);
            //Sekil ucun birinci valid
            if (!aparatVM.Photo.CheckContentType("image/")) { ModelState.AddModelError("Photo", Messages.FileTypeMustBeImage); return View(aparatVM); }
            //ikinci
            if (aparatVM.Photo.CheckFileSize(200)) { ModelState.AddModelError("Photo", Messages.FileSizeMustBe200KB); return View(aparatVM); }
            //3



            string rootPath = Path.Combine(_webHostEnvironment.WebRootPath, "assets", "imgs");
            //4
            string fileName = await aparatVM.Photo.SaveAsync(rootPath); 
            //string fileName = Guid.NewGuid().ToString()+aparatVM.Photo.FileName;
            //using (FileStream fileStream = new FileStream(Path.Combine(rootPath, fileName), FileMode.Create)) 
            //{
            //    await aparatVM.Photo.CopyToAsync(fileStream);
            //}



            Aparat aparat = new Aparat 
            {
            Title=aparatVM.Title,
            FullName=aparatVM.FullName,
            DateTime = DateTime.Now,
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

        // POST: AparatController/Delete/5
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
