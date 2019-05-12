using System.Collections.Generic;
using System.Threading.Tasks;
using Reservatie.Core.Models;

namespace Reservatie.Models.Repositories
{
    public interface IScreeningRepo
    {
        Task<IEnumerable<Screening>> GetAllScreenings();
        void AddScreening(Screening screening);
    }
}