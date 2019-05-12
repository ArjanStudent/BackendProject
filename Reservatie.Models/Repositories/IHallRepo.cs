using System.Collections;
using System.Threading.Tasks;

namespace Reservatie.Models.Repositories
{
    public interface IHallRepo
    {
        Task<IEnumerable> GetAllHalls();
    }
}