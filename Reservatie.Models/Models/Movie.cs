using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Description { get; set; }

        //Duratie van de film uitgedrukt in minuten
        [Required]
        [Display(Name = "Duration Movie")]
        [Range(60,500)]
        public int Duration_Movie { get; set; }

        public ICollection<Screening> Screenings { get; set; }
    }
}
