using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservatie.Core.Models;

namespace Reservatie.Core.Repositories
{
    public interface IHallRepo
    {
        void AddHall(Hall hall);
        void DeleteHall(int id, Hall hall);
        void EditHall(int id, Hall hall);
        Task<IEnumerable> GetAllHallNamesAsync();
        Task<Hall> GetHallById(int id);
        Task<IEnumerable<Hall>> GetHallsAsync();
    }
}