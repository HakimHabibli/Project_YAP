using Agsaqqallarsurasi.Areas.Admin.ViewModels;
using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Agsaqqallarsurasi.Utilities.Constants;
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

    public class HeyetController : Controller
	{
		private readonly AppDbContext _context;

		public HeyetController(AppDbContext context)
		{
			_context = context;
		}

		// GET: HeyetController
		public async Task<ActionResult> Index()
		{
			List<IdareHeyeti> heyetis = await _context.IdareHeyeti.OrderByDescending(p => p.Id).ToListAsync();
			return View(heyetis);
		}

        public async Task<IActionResult> Create()
        {
            CreateHeyetVM createHeyetVM = new CreateHeyetVM();

            return View(createHeyetVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateHeyetVM createHeyetVM)
		{
			if (!ModelState.IsValid) { return NotFound(); }
			IdareHeyeti idareHeyeti = new IdareHeyeti 
			{ 
				Description = createHeyetVM.Description,
				FullName = createHeyetVM.FullName,
			};
			await _context.IdareHeyeti.AddAsync(idareHeyeti);
			await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
		// GET: HeyetController/Delete/5
		public async Task<ActionResult> Delete(int id)
		{
            IdareHeyeti idare = await _context.IdareHeyeti.FindAsync(id);
            if (idare == null) return NotFound();
            _context.IdareHeyeti.Remove(idare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            IdareHeyeti heyeti = await _context.IdareHeyeti.FindAsync(id);
            if (heyeti == null) return NotFound();
            UpdateHeyetVM updateHeyetVM = new UpdateHeyetVM()
            {
                Description= heyeti.Description,
                FullName= heyeti.FullName,
                Id = id
            };

            return View(updateHeyetVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateHeyetVM updateHeyetVM)
        {
            if (!ModelState.IsValid) return View(updateHeyetVM);
          
            IdareHeyeti idareHeyeti = await _context.IdareHeyeti.FindAsync(updateHeyetVM.Id);
         
            idareHeyeti.Id=updateHeyetVM.Id;
            idareHeyeti.FullName=updateHeyetVM.FullName;
            idareHeyeti.Description=updateHeyetVM.Description;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

    }
}
