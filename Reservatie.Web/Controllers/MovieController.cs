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
    public class MovieController : Controller
    {
        // GET: Movie

        private readonly IMovieRepo _movieRepo;
        private readonly ApplicationDbContext _context;
        public MovieController(IMovieRepo movieRepo, ApplicationDbContext context)
        {
            this._movieRepo = movieRepo;
            this._context = context;

        }

        public async Task<ActionResult> Index()
        {
            var movies = await _movieRepo.GetMoviesAsync();
            return View("Index", movies);
        }

        // GET: Movie/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Title,Director,Description,Duration_Movie")]Movie movie)
        {
            if(ModelState.IsValid)
                try
                {
                    // TODO: Add insert logic here
                    _movieRepo.AddMovie(movie);
                    return RedirectToAction(nameof(Index));
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("","Create is unable to save");
                    Console.WriteLine(ex);

                    return View();
                }
            else
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        [Authorize]
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Movie/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Movie movie)
        {
            try
            {
                // TODO: Add update logic here
                _movieRepo.EditMovie(id, movie);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Movie/Delete/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                // TODO: Add delete logic here
                _movieRepo.DeleteMovie(id, movie);
                return RedirectToAction(nameof(Index));
            }
            catch(Exception e)
            {
                ModelState.AddModelError("", "Application is unable to remove");
                Console.WriteLine(e.InnerException);
                return View();
            }
        }
    }
}