using Microsoft.EntityFrameworkCore;
using Reservatie.Core.Data;
using Reservatie.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Repositories
{
    public class ScreeningRepo : IScreeningRepo
    {
        private readonly ApplicationDbContext _context;
        public ScreeningRepo(ApplicationDbContext context, IHallRepo hallRepo, IMovieRepo movieRepo)
        {
            this._context = context;

        }

        public async Task<IEnumerable<Screening>> GetAllScreenings()
        {
            var result = await _context.Screening
                .Include(s => s.Movie)
                .Where(s => s.Movie.Id == s.Movie_Id)
                
                .Include(s => s.Hall)
                .Where(s => s.Hall.Id == s.Hall_Id)
                .AsNoTracking()
                .ToListAsync();
            return result;
        }

        public async void AddScreening(Screening screening)
        {
            try
            {
                Screening newScreening = new Screening();
                newScreening.Hall = screening.Hall;
                newScreening.Hall_Id = screening.Hall_Id;
                    newScreening.Movie = screening.Movie;
                    newScreening.Movie_Id = screening.Movie_Id;
                    newScreening.Reservations = screening.Reservations;
                    newScreening.Programmation = screening.Programmation;
                    await _context.Screening.AddAsync(newScreening);
                    _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
        public async Task<Screening> GetScreeningById(int id)
        {
            Screening selectedScreening = new Screening();
            selectedScreening = await _context.Screening.Where(s => s.Id == id)
                .FirstOrDefaultAsync<Screening>();
            return selectedScreening;
        }


        public async void EditScreening(int id, Screening screening)
        {
            try
            {
                Screening editScreening = new Screening();
                editScreening = GetScreeningById(id).Result;
                editScreening.Hall = screening.Hall;
                editScreening.Hall_Id = screening.Hall_Id;
                editScreening.Movie = screening.Movie;
                editScreening.Movie_Id = screening.Movie_Id;
                editScreening.Reservations = screening.Reservations;
                editScreening.Programmation = screening.Programmation;
                _context.Screening.Update(editScreening);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

    }
}
