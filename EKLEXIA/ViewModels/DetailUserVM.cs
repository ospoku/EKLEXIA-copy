using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EKLEXIA.ViewModels
{
    public class DetailUserVM
    {

        public string Fullname { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string BranchId { get; set; }
        public SelectList Branches { get; set; }
        public string ApplicationRoleId { get; set; }
        public List<SelectListItem> ApplicationRoles { get; set; }

    }
}
