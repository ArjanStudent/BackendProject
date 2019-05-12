using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Models
{
    // Seat reserved bepaald welke stoel gereserveerd wordt bij de reservatie
    public class Seat_Reserved
    {
        [Key]
        public int Id { get; set; }

        public Seat Seat { get; set; }
        public Screening Screening { get; set; }
        public Reservation Reservation { get; set; }
    }
}
