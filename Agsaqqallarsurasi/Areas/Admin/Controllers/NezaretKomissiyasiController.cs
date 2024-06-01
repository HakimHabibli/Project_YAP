using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class NezaretKomissiyasiController : Controller
	{
		private readonly AppDbContext _context;

		public NezaretKomissiyasiController(AppDbContext context)
		{
			_context = context;
		}

		// GET: NezaretKomissiyasiController
		public async Task<ActionResult> Index()
		{
			List<NezaretKomissiyasi> nezaretKomissiyasis = await _context.NezaretKomissiyasi.OrderByDescending(p=>p.Id).ToListAsync();
			return View(nezaretKomissiyasis);
		}

		// GET: NezaretKomissiyasiController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: NezaretKomissiyasiController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: NezaretKomissiyasiController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
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

		// GET: NezaretKomissiyasiController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: NezaretKomissiyasiController/Edit/5
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

		// GET: NezaretKomissiyasiController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: NezaretKomissiyasiController/Delete/5
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
