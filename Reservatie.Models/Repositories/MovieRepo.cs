using Microsoft.EntityFrameworkCore;
using Reservatie.Core.Data;
using Reservatie.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Models.Repositories
{
    public class MovieRepo : IMovieRepo
    {
        private readonly ApplicationDbContext _context;
        public MovieRepo(ApplicationDbContext context)
        {
            this._context = context;

        }


        public async Task<IEnumerable> GetAllTitles()
        {
            return await _context.Movie.Select(column => column.Title).ToListAsync();

        }

        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _context.Movie.ToListAsync();
        }

        public async Task<Movie> GetMovieById(int id)
        {
            Movie selectedMovie = new Movie();
            selectedMovie = _context.Movie.Where(m => m.Id == id)
                .SingleOrDefaultAsync()
                .Result;
            return selectedMovie;


                            
        }

        public async void AddMovie(Movie movie)
        {
            try
            {
                Movie newMovie = new Movie()
                {
                    Description = movie.Description,
                    Director = movie.Director,
                    Title = movie.Title,
                    Duration_Movie = movie.Duration_Movie
                };
                await _context.Movie.AddAsync(newMovie);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
        public async void EditMovie(int id, Movie movie)
        {
            try
            {
                Movie editMovie = new Movie();
                editMovie = GetMovieById(id).Result;
                editMovie.Description = movie.Description;
                editMovie.Director = movie.Director;
                editMovie.Title = movie.Title;
                editMovie.Duration_Movie = movie.Duration_Movie;
                _context.Movie.Update(editMovie);
                await _context.SaveChangesAsync();
      
                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public void DeleteMovie(int id, Movie movie)
        {
            try
            {
                Movie deleteMovie = new Movie();
                deleteMovie = GetMovieById(id).Result;
                deleteMovie = GetMovieById(id).Result;
                deleteMovie.Description = movie.Description;
                deleteMovie.Director = movie.Director;
                deleteMovie.Title = movie.Title;

                _context.Movie.Remove(deleteMovie);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }


    }
}
