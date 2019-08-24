using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservatie.Core.Models
{
    public class ApplicationUser : IdentityUser
    {

        public string Name { get; set; }
        //public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    //public class ApplicationRole : IdentityRole
    //{
    //    public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    //}

    //public class ApplicationUserRole : IdentityUserRole<string>
    //{
    //    public virtual ApplicationUser User { get; set; }
    //    public virtual ApplicationRole Role { get; set; }
    //}
}
