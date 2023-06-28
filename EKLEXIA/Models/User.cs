using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EKLEXIA.Models
{
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UserId { get; set; }
        public string ?Firstname { get; set; }
        public string? Surname { get; set; }

        public string Fullname
        {
            get
            {
                return Firstname
                    + "  "
                    + Surname;
            }
        }

        public bool IsDeleted { get; set; }

     
    }
}
