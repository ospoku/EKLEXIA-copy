using EKLEXIA.Models;
using EKLEXIA.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class Users : ViewComponent
    {
        public readonly RoleManager<Role> rol;
        public readonly XContext xct;
        public readonly UserManager<User> usm;
        public Users(XContext XContext, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            rol = roleManager;
            xct = XContext;
            usm = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var userList = usm.Users.Where(u => u.IsDeleted == false).Select(u => new UsersVM
            {
                UserId = u.Id,
                Fullname = u.Fullname,


                Username = u.UserName,
                Email = u.Email,
                Telephone = u.PhoneNumber,

                Role = string.Join(",", from p in xct.UserRoles
                                        join role in xct.Roles on p.RoleId equals role.Id
                                        where p.UserId == u.Id
                                        select role.Name.ToString())


            }).ToList();

            return View(userList);
        }
    }
}
