
using EKLEXIA.Data;
using EKLEXIA.DataProtection;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics.Metrics;

namespace EKLEXIA.ViewComponents
{
    public class ManageGroup : ViewComponent
    {
        public readonly XContext xct;
        public ManageGroup(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke(string Id)
        {
            var allMembers = xct.Members.ToList();
            var groupMembers = xct.MemberGroups.Where(g => g.GroupId == Encryption.Decrypt(Id)).Select(m => m.MemberId);

            Group group = xct.Groups.FirstOrDefault(g => g.GroupId == Encryption.Decrypt(Id));

            ManageGrpVM manageGrpVM = new()
            {
                Members = allMembers.Select(m=>new SelectListItem { Selected = groupMembers.Contains(m.MemberId),Text=m.Fullname,Value=m.MemberId }).ToList(),
                Groupname = group.Name.ToString(),
            };

            
          
           

          
            //userLetterVM.AvailableUsers = allUsers.Select(u => new CheckBoxItem()


            //{
            //    Id = u.Id,
            //    Name = u.Name,
            //    IsChecked = selectedUsers.Contains(u.Id)
            //}).ToList();

        //    return View(manageGrpVM);
        //}

            return View(manageGrpVM);
        }
    }
}
