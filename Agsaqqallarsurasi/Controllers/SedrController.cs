﻿using Agsaqqallarsurasi.DAL;
using Agsaqqallarsurasi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agsaqqallarsurasi.Controllers
{
    public class SedrController : Controller
    {
        private readonly AppDbContext _context;

        public SedrController(AppDbContext context)
        {
            _context = context;
        }

        // GET: SedrController
        public async Task<ActionResult> Index()
        {
            
            return View(await _context.Sedr.ToListAsync());
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
