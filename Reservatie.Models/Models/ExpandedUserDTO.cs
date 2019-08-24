using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Models.Models
{
    public class ExpandedUserDTO
    { 
        [Key]
        [Display(Name ="User Name")]
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public List<string> Roles { get; set; }
    }
}
