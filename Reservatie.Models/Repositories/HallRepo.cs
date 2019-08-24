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
    public class HallRepo : IHallRepo
    {
        private readonly ApplicationDbContext _context;
        public HallRepo(ApplicationDbContext context)
        {
            this._context = context;

        }

        public async Task<IEnumerable<Hall>> GetHallsAsync()
        {
            return await _context.Hall.ToListAsync();
        }

        public async Task<IEnumerable> GetAllHallNamesAsync()
        {
            return await _context.Hall.Select(column => column.Name).ToListAsync();

        }


        public async Task<Hall> GetHallById(int id)
        {
            Hall selectedHall = new Hall();
            selectedHall = await _context.Hall.Where(h => h.Id == id)
                .FirstOrDefaultAsync<Hall>();
            return selectedHall;

        }

        public async void AddHall(Hall hall)
        {
            try
            {
                Hall newHall = new Hall()
                {
                    Description = hall.Description,
                    Name = hall.Name,
                    Total_Seats = hall.Total_Seats
                };
                await _context.Hall.AddAsync(newHall);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public async void EditHall(int id, Hall hall)
        {
            try
            {
                Hall editHall = new Hall();
                editHall = GetHallById(id).Result;
                editHall.Description = hall.Description;
                editHall.Name = hall.Name;
                editHall.Total_Seats = hall.Total_Seats;
                _context.Hall.Update(editHall);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public void DeleteHall(int id, Hall hall)
        {
            try
            {
                Hall deleteHall = new Hall();
                deleteHall = GetHallById(id).Result;
                deleteHall.Description = hall.Description;
                deleteHall.Name = hall.Name;
                deleteHall.Total_Seats = hall.Total_Seats;

                _context.Hall.Remove(deleteHall);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

    }
}
