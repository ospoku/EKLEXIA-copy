using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EKLEXIA.ViewModels
{
    public class ViewUsersVM
    {
        public string UserId { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Branch { get; set; }
        public string Role { get; set; }
    }
}
