using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservatie.API.Models
{
    public class Movies_DTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public int Duration_Movie { get; set; }
    }
}
