using Reservatie.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Data
{
    public class DataInitializer : IDataInitializer
    {
        private readonly ApplicationDbContext _context;
        public DataInitializer(ApplicationDbContext context)
        {
            this._context = context;
            //this.Movies = this.CreateMovies(5);


        }
        public IEnumerable<Movie> Movies { get; set; }

        public void CreateData()
        {
            CreateScreening();

        }
        private List<Movie> _movies = new List<Movie>();
        private List<Movie> CreateMovies(int nmbrMovies)
        {

            for (var i = 1; i <= nmbrMovies; i++)
            {
                Movie movie = new Movie();
                movie.Id = i;
                movie.Title = "Avengers" + i;
                movie.Description = "Movie " + i + "in the series";
                movie.Director = "Russo";
                movie.Duration_Movie = 130 + i;

                _movies.Add(movie);
            }
            foreach (Movie m in _movies)
            {
                _context.Movie.Add(m);
            }
            return _movies;
        }
        private void CreateHalls()
        {
            Hall hall = new Hall()
            {
                Description = "Zaal 1 van de cinema.",
                Name = "Sfinx",
                Total_Seats = 65
            };
            _context.Hall.Add(hall);
            _context.SaveChanges();
        }


        private void CreateScreening()
        {
            Screening screening = new Screening()
            {
                Movie_Id = 1,
                Hall_Id = 1,
                Programmation = DateTime.Now.AddDays(1)
            };
            _context.Screening.Add(screening);
            _context.SaveChanges();
        }
    }

       
}

 

   