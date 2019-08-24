using Microsoft.EntityFrameworkCore;
using Reservatie.Core.Data;
using Reservatie.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Repositories
{
    public class ReservationRepo : IReservationRepo
    {
        private readonly ApplicationDbContext _context;
        public ReservationRepo(ApplicationDbContext context, IHallRepo hallRepo, IMovieRepo movieRepo)
        {
            this._context = context;
        }
        //GetAllReservations()
        //GetReservationByUserId()
        //GetReservationById()
        //AddReservation()
        //DeleteReservation()
        //EditReservation()

        public async Task<IEnumerable<Reservation>> GetAllReservations()
        {
            return await _context.Reservation.ToListAsync();
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByUserId(Guid id)
        {
            return await _context.Reservation.Where(r => r.User_Id == id).ToListAsync();
        }

        public async void AddReservation(Reservation reservation, Guid userId)
        {
            try
            {
                Reservation newReservation = new Reservation()
                {
                    Reservation_Status = 1,
                    Date_Reserved = DateTime.Now,

                    User_Id = userId,
                    Screening = reservation.Screening,
                    Seats_Reserved = reservation.Seats_Reserved

    };
                await _context.Reservation.AddAsync(newReservation);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }



        //public async Task<IEnumerable<Reservation>> GetReservationsByUserId(Guid id)
        //{
        //    <IEnumerable<Reservation>> reservations = Enumerable.Empty<Reservation>();
        //    reservations = await _context.Reservation.Where(r => r.User_Id == id);
        //    return reservations;

        //}

    }
}
