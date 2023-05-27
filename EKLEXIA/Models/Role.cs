using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKLEXIA.Models
{
    public class Role : IdentityRole
    {
        public string Name { get; set; }
    }
}
