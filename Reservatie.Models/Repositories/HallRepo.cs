using Microsoft.EntityFrameworkCore;
using Reservatie.Core.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Models.Repositories
{
    public class HallRepo : IHallRepo
    {
        private readonly ApplicationDbContext _context;
        public HallRepo(ApplicationDbContext context)
        {
            this._context = context;

        }
        public async Task<IEnumerable> GetAllHalls()
        {
            return await _context.Hall.Select(column => column.Name).ToListAsync();

        }
    }
}
