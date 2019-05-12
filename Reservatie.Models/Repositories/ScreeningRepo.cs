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
                Screening newScreening = new Screening()
                {
                    
                };
                await _context.Screening.AddAsync(newScreening);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

    }
}
