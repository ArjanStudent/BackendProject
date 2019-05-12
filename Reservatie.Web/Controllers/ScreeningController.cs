﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservatie.Core.Data;
using Reservatie.Core.Models;
using Reservatie.Models.Repositories;

namespace Reservatie.Web.Controllers
{
    public class ScreeningController : Controller
    {
        private readonly IScreeningRepo _screeningRepo;
        private readonly IMovieRepo _movieRepo;
        private readonly IHallRepo _hallRepo;
        public ScreeningController(IScreeningRepo screeningRepo, IMovieRepo movieRepo, IHallRepo hallRepo)
        {
            this._movieRepo = movieRepo ;
            this._hallRepo = hallRepo;
            this._screeningRepo = screeningRepo;

        }
        // GET: Cinema
        public async Task<ActionResult> Index()
        {
            var screenings = await _screeningRepo.GetAllScreenings();
            return View("Index",screenings);
        }

        // GET: Cinema/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Cinema/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.listMovies = _movieRepo.GetAllTitles().Result;
            ViewBag.listHalls = _hallRepo.GetAllHalls().Result;
            return View();
        }

        // POST: Cinema/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Movie_Id","Hall_Id","Programmation")] Screening screening)
        {
            try
            {
                // TODO: Add insert logic here
                _screeningRepo.AddScreening(screening);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cinema/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Cinema/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Cinema/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Cinema/Delete/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}