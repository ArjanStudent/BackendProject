using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Models
{
    // De hall is de zaal waar de screening plaatsvind, waar de film wordt afgespeeld
    public class Hall
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Total_Seats { get; set; }

        public ICollection<Screening> Screenings { get; set; }
        public ICollection<Seat> Seats { get; set; }
    }
}
