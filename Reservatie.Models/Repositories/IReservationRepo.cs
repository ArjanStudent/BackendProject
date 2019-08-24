using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservatie.Core.Models;

namespace Reservatie.Core.Repositories
{
    public interface IReservationRepo
    {
        void AddReservation(Reservation reservation, Guid userId);
        Task<IEnumerable<Reservation>> GetAllReservations();
        Task<IEnumerable<Reservation>> GetReservationsByUserId(Guid id);
    }
}