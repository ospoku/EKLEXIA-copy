using EKLEXIA.Models;
using EKLEXIA.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace EKLEXIA.ViewComponents
{
    public class ViewUsers : ViewComponent
    {
        public readonly RoleManager<Role> rol;
        public readonly XContext xct;
        public readonly UserManager<User> usm;
        public ViewUsers(XContext XContext, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            rol = roleManager;
            xct = XContext;
            usm = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var userList = usm.Users.Where(u => u.IsDeleted == false).Select(u => new ViewUsersVM
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
