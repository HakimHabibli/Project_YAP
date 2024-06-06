using Agsaqqallarsurasi.Areas.Admin.ViewModels;
using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RayonHeyetController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public RayonHeyetController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: MuavinController
        public async Task<ActionResult> Index()
        {
            List<RayonHeyet> muavins = await _context.RayonHeyets.OrderByDescending(p => p.Id).ToListAsync();
            return View(muavins);
        }

        public async Task<IActionResult> Create()
        {
            CreateRayonHeyetVM createHeyetVM = new CreateRayonHeyetVM();

            return View(createHeyetVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRayonHeyetVM createHeyetVM)
        {
            if (!ModelState.IsValid) { return NotFound(); }
            RayonHeyet idareHeyeti = new RayonHeyet
            {
                
                Description = createHeyetVM.Description,
                FullName = createHeyetVM.FullName,
            };
            await _context.RayonHeyets.AddAsync(idareHeyeti);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
        // GET: HeyetController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            RayonHeyet idare = await _context.RayonHeyets.FindAsync(id);
            if (idare == null) return NotFound();
            _context.RayonHeyets.Remove(idare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            RayonHeyet heyeti = await _context.RayonHeyets.FindAsync(id);
            if (heyeti == null) return NotFound();
            UpdateRayonHeyetVM updateHeyetVM = new UpdateRayonHeyetVM()
            {
                Description = heyeti.Description,
                FullName = heyeti.FullName,
                Id = id
            };

            return View(updateHeyetVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateRayonHeyetVM updateHeyetVM)
        {
            if (!ModelState.IsValid) return View(updateHeyetVM);

            RayonHeyet idareHeyeti = await _context.RayonHeyets.FindAsync(updateHeyetVM.Id);

            idareHeyeti.Id = updateHeyetVM.Id;
            idareHeyeti.FullName = updateHeyetVM.FullName;
            idareHeyeti.Description = updateHeyetVM.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
