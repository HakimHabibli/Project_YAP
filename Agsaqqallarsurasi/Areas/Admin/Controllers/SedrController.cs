using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class SedrController : Controller
	{
		private readonly AppDbContext _appDbContext;

		public SedrController(AppDbContext appDbContext)
		{
			_appDbContext = appDbContext;
		}

		// GET: SedrController
		public async Task<ActionResult> Index()
		{
			List<Sedr> sedrs = await _appDbContext.Sedr.OrderByDescending(p => p.Id).ToListAsync();
			return View(sedrs);
		}

		// GET: SedrController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: SedrController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: SedrController/Create
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

		// GET: SedrController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: SedrController/Edit/5
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

		// GET: SedrController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: SedrController/Delete/5
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
