using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reservatie.Core.Data;
using Reservatie.Core.Repositories;
using Reservatie.Web.ViewModels;

namespace Reservatie.Web.Controllers
{
    public class ReservationController : Controller
    {

        private readonly IReservationRepo _reservationRepo;
        private readonly IScreeningRepo _screeningRepo;
        private readonly IMovieRepo _movieRepo;
        private readonly IHallRepo _hallRepo;
        private readonly ApplicationDbContext _context;
        public ReservationController(IReservationRepo reservationRepo, ApplicationDbContext context, IScreeningRepo screeningRepo, IMovieRepo movieRepo, IHallRepo hallRepo)
        {
            this._reservationRepo = reservationRepo;
            this._context = context;
            this._movieRepo = movieRepo;
            this._hallRepo = hallRepo;
            this._screeningRepo = screeningRepo;

        }
        // GET: Reservation
        public async Task<ActionResult> Index()
        {
            var reservations = await _reservationRepo.GetAllReservations();
            return View("Index", reservations);
        }

        // GET: Reservation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Reservation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reservation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ReservationVM vm = new ReservationVM(_reservationRepo, _screeningRepo);
                return View(vm);

            }
            catch
            {
                return View();
            }

        }

        // GET: Reservation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Reservation/Edit/5
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

        // GET: Reservation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Reservation/Delete/5
        [HttpPost]
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