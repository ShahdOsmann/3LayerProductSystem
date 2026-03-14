using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSystem.DAL
{
    public class ApplicationUser: IdentityUser
    {
        public String FirstName { get; set; } = null!;
        public String? LastName { get; set; }
    }
}
