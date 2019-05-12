using System.Collections.Generic;
using Reservatie.Core.Models;

namespace Reservatie.Core.Data
{
    public interface IDataInitializer
    {
        IEnumerable<Movie> Movies { get; set; }

        void CreateData();
    }
}