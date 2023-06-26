
using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class Birthdays : ViewComponent
    {
        public readonly XContext xct;
        public Birthdays(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var MembersList = xct.Members.Where(m =>m.DoB== DateTime.Today & m.IsDeleted==false).Select(m => new MembersVM
            {
                MemberId = m.MemberId,
                Telephone = m.Telephone,
               
                Fullname = m.Fullname,
                DateofBirth = m.DoB,
                GenderId = m.Gender.Name,
                Age = m.Age,
                RegionId = m.RegionId,
                Address = m.Address,
                IDNumber = m.IDNumber,

             

            }).ToList();
            return View(MembersList);
        }
    }
}
