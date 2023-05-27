using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class EditUser : ViewComponent
    {
        public readonly UserManager<User> USM;
        public readonly RoleManager<Role> ROL;
        public readonly XContext xct;
        public EditUser(UserManager<User> userManager,RoleManager<Role> rolManager,XContext XContext)
        {
            USM = userManager;
            ROL = rolManager;
            xct = XContext;
        }

        public IViewComponentResult Invoke(string Id)
        {

            User userToEdit = (from u in USM.Users where u.Id == Id select u).FirstOrDefault();

            EditUserVM editUserVM = new EditUserVM
            {
              
                Email = userToEdit.Email,
                Firstname = userToEdit.Firstname,
                Username = userToEdit.UserName,
                Surname = userToEdit.Surname,
                Telephone = userToEdit.PhoneNumber,
               ApplicationRoleId = ROL.Roles.Single(r => r.Name == USM.GetRolesAsync(userToEdit).Result.Single()).Id,
              
                ApplicationRoles = ROL.Roles.Select(r => new SelectListItem { Text = r.Name, Value = r.Id }).ToList(),
            };

            return View(editUserVM);
        }
    }
}
