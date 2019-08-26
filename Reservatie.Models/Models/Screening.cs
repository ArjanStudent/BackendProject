using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Models
{
    // Screening is de programmatie van een film
    public class Screening
    {
        [Key]
        public int Id { get; set; }
        public DateTime Programmation { get; set; }

        [Column("Movie_Id")]
        [ForeignKey("Movie")]
        public int Movie_Id { get; set; }
        public Movie Movie { get; set; }

        [Column("Hall_Id")]
        [ForeignKey("Hall")]
        public int Hall_Id { get; set; }
        public Hall Hall { get; set; }


        public ICollection<Reservation> Reservations { get; set; }

    }
}

