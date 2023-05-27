using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class DetailUser : ViewComponent
    {
        public UserManager<User> usm;

        public DetailUser(UserManager<User> userManager)
        {
            usm = userManager;
        }

        public IViewComponentResult Invoke(string Id)
        {

            User user = usm.FindByIdAsync(Id).Result;

            DetailUserVM UserDetail = new DetailUserVM()
            {
                Email = user.Email,
                Fullname = user.Fullname,

                Telephone = user.PhoneNumber,
                Username = user.UserName,
                BranchId = user.BranchId,
            };





            return View(UserDetail);
        }

    }
}
