using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace farhaproject1.Models
{
    public class AdminApplication : IdentityUser
    {
        public string Name { get; set; }
        public string CenterName { get; set; }
        public string CenterLocation { get; set; }
    }
}
