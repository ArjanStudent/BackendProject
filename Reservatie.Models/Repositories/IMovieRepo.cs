using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservatie.Core.Models;

namespace Reservatie.Models.Repositories
{
    public interface IMovieRepo
    {
        void AddMovie(Movie movie);
        void DeleteMovie(int id, Movie movie);
        void EditMovie(int id, Movie movie);
        Task<IEnumerable> GetAllTitles();
        Task<Movie> GetMovieById(int id);
        Task<IEnumerable<Movie>> GetMoviesAsync();
    }
}