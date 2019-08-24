using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reservatie.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movie { get; set; }
        public DbSet<Seat> Seat { get; set; }
        public DbSet<Screening> Screening { get; set; }
        public DbSet<Reservation> Reservation { get; set; }
        public DbSet<Hall> Hall { get; set; }
        public DbSet<Seat_Reserved> Seat_reserved {get;set;}


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           // builder.Entity<ApplicationUser>().HasKey<string>(l => l.Id);


            builder.Entity<Screening>(entity =>
            {
                entity.Property(e => e.Movie_Id).HasColumnName("Movie_Id");
                entity.Property(e => e.Hall_Id).HasColumnName("Hall_Id");
                
            });

        }

    }
}
