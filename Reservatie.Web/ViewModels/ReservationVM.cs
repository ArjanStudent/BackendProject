using Microsoft.AspNetCore.Mvc.Rendering;
using Reservatie.Core.Models;
using Reservatie.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservatie.Web.ViewModels
{
    public class ReservationVM
    {
        public ReservationVM(IReservationRepo reservationRepo, IScreeningRepo screeningRepo)
        {
            this.screening = new SelectList(screeningRepo.GetAllScreenings().Result, "Screening", "screening.Movie.Title", Reservation.Screening);
        }
        public Reservation Reservation { get; set; }
        public SelectList screening { get; set; }

    }
}
