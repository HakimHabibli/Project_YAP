using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Areas.Admin.Controllers
{
	[Area("Admin")]

	public class MuavinController : Controller
	{
		private readonly AppDbContext _context;

		public MuavinController(AppDbContext context)
		{
			_context = context;
		}

		// GET: MuavinController
		public async Task<ActionResult> Index()
		{
			List<Muavin> muavins = await _context.Muavins.OrderByDescending(p => p.Id).ToListAsync();
			return View(muavins);
		}

		// GET: MuavinController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: MuavinController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: MuavinController/Create
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
