using System.Collections.Generic;
using System.Threading.Tasks;
using Reservatie.Core.Models;

namespace Reservatie.Core.Repositories
{
    public interface IScreeningRepo
    {
        Task<IEnumerable<Screening>> GetAllScreenings();
        void AddScreening(Screening screening);
        Task<Screening> GetScreeningById(int id);
    }
}