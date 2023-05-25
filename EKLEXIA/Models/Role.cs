using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKKLESIA.Models
{
    public class Role : IdentityRole
    {
        public string Rolename { get; set; }
    }
}
