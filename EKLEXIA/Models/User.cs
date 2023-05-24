using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKKLESIA.Models
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }

        public string Fullname
        {
            get
            {
                return Firstname
                    + "  "
                    + Surname;
            }
        }


        public string BranchId { get; set; }
        public bool IsDeleted { get; set; }

        public static implicit operator IdentityResult(User v)
        {
            throw new NotImplementedException();
        }
    }
}
