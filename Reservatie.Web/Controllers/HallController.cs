using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservatie.Core.Data;
using Reservatie.Core.Models;
using Reservatie.Core.Repositories;

namespace Reservatie.Web.Controllers
{
    public class HallController : Controller
    {

        private readonly IHallRepo _hallRepo;
        private readonly ApplicationDbContext _context;
        public HallController(IHallRepo hallRepo, ApplicationDbContext context)
        {
            this._hallRepo = hallRepo;
            this._context = context;

        }

        // GET: Hall
        public async Task<ActionResult> Index()
        {
            var halls = await _hallRepo.GetHallsAsync();
            return View("Index", halls);
        }

        // GET: Hall/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Hall/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hall/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Name,Description,Total_Seats")]Hall hall)
        {
            if (ModelState.IsValid)
                try
                {
                    // TODO: Add insert logic here
                    _hallRepo.AddHall(hall);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Create is unable to save");
                    Console.WriteLine(ex);

                    return View();
                }
            else
            {
                return View();
            }
        }

        // GET: Hall/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hall/Edit/5
        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hall hall)
        {
            try
            {
                // TODO: Add update logic here
                _hallRepo.EditHall(id, hall);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hall/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hall/Delete/5
        [HttpPost]
        [Authorize]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hall hall)
        {
            try
            {
                // TODO: Add delete logic here
                _hallRepo.DeleteHall(id, hall);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Application is unable to remove");
                Console.WriteLine(e.InnerException);
                return View();
            }
        }
    }
}