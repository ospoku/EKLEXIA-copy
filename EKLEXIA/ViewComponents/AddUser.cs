﻿

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class AddUser:ViewComponent
    {
        public readonly XContext xct;
        public readonly UserManager<User> usm;
        public readonly RoleManager<AppRole> rmg;

        public AddUser(XContext XContext,UserManager<User> userManager, RoleManager<AppRole> roleManager)
        {
            usm = userManager;
            xct = XContext;
            rmg = roleManager;
        }

        public IViewComponentResult Invoke()
        {
            AddUserVM addUserVM = new AddUserVM()
            {
               
                ApplicationRoles = rmg.Roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Id }).ToList(),
            };
            return View(addUserVM);
        }

    }
}
