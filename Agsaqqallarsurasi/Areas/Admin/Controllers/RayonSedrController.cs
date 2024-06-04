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


    public class RayonSedrController : Controller
	{
		private readonly AppDbContext _context;
		private readonly IWebHostEnvironment _webHostEnvironment;


        public RayonSedrController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: RayonSedrController
        public async Task<ActionResult> Index()
		{
			List<RayonSedr> rayonSedrs = await _context.RayonSedr.OrderByDescending(p => p.Id).ToListAsync();
			return View(rayonSedrs);
		}
		// GET: RayonSedrController/Create
		public async Task<ActionResult> Create()
		{
			CreateRayonSedrVM createRayonSedr= new CreateRayonSedrVM();
			return View(createRayonSedr);
		}
		// POST: RayonSedrController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(CreateRayonSedrVM createRayonSedr)
		{
			if (!ModelState.IsValid) return NotFound();
			RayonSedr rayonSedr = new RayonSedr()
			{
				FullName = createRayonSedr.FullName,
				Title = createRayonSedr.Title
				
			};
			await _context.RayonSedr.AddAsync(rayonSedr);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		
		public async Task<ActionResult> Delete(int id)
		{
			RayonSedr rayonSedr= await _context.RayonSedr.FindAsync(id);
			if (rayonSedr == null) return NotFound();

            _context.RayonSedr.Remove(rayonSedr);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int id)
        {
            RayonSedr rayonSedr = await _context.RayonSedr.FindAsync(id);
            if (rayonSedr == null) return NotFound();
            UpdateRayonSedr updateRayonSedr = new UpdateRayonSedr()
            {
                Title = rayonSedr.Title,
                FullName = rayonSedr.FullName,
                Id = id
            };
            return View(updateRayonSedr);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(UpdateRayonSedr update)
        {
            if (!ModelState.IsValid) return View(update);
           

            RayonSedr rayonSedr = await _context.RayonSedr.FindAsync(update.Id);

            rayonSedr.Id = update.Id;
            rayonSedr.FullName = update.FullName;
            rayonSedr.Title = update.Title;
          
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }
    }
}
