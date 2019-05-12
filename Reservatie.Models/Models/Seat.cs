using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Models
{
    // Een seat is een stoel in een zaal
    public class Seat
    {
        [Key]
        public int Id { get; set; }

        [Range(1,6)]
        public int Row_Seat { get; set; }

        [Range(1, 15)]
        public int Number_Seat { get; set; }

        public Hall Hall { get; set; }
        public ICollection<Seat_Reserved> Seats_Reserved { get; set; }
       
    }
}
