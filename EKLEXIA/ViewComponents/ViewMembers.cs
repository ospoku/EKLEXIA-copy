
using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class ViewMembers : ViewComponent
    {
        public readonly XContext xct;
        public ViewMembers(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var MembersList = xct.Members.Where(m => m.IsDeleted == false).Select(m => new ViewMembersVM
            {
                MemberId = m.MemberId,
                Telephone = m.Telephone,
                Hometown = m.Hometown,
                Fullname = m.Fullname,
                DateofBirth = m.DoB,
                GenderId = m.Gender.GenderName,
                Age = m.Age,
                RegionId = m.RegionId,
                Address = m.Address,
                IDNumber = m.IDNumber,

                CareerId = m.CareerId,
               // Photo = m.Photo,

            }).ToList();
            return View(MembersList);
        }
    }
}
