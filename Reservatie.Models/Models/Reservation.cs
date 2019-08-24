using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public int Reservation_Status { get; set; }
        public DateTime Date_Reserved { get; set; }

        public Guid User_Id { get; set; }
        public Screening Screening { get; set; }
        public ICollection<Seat_Reserved> Seats_Reserved { get; set; }

    }
}
