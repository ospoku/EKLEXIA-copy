using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class IDCards : ViewComponent
    {
        public readonly XContext xct;
        public IDCards(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var MembersList = xct.Members.Where(a => a.IsDeleted == false).Select(a => new ViewCardListVM
            {
                MemberId = a.MemberId,
                Telephone=a.Telephone,
         
                Fullname = a.Fullname,
                DateofBirth = a.DoB,
                GenderId = a.Gender.Name,
                Age=a.Age,

                Address = a.Address,





            }).ToList();
            return View(MembersList);
        }
    }
}
