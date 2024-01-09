using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBay.Core.Entities
{
    public class AppUser : IdentityUser
    { 
        public string Name { get; set; }
        public string Username { get; set; }
        public bool IsRemained { get; set; }
    }
}
