
using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.DataProtection;

namespace EKLEXIA.ViewComponents
{
    public class ViewMembers : ViewComponent
    {
        public readonly XContext xct;
        private readonly IDataProtector protector;
        public ViewMembers(XContext XContext, IDataProtectionProvider provider)
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
                Photo = m.Photo,

            }).ToList();
            foreach (var member in MembersList)
            {
                var stringId= member.MemberId.ToString();
                member.EncryptedId = protector.Protect(stringId);
            }
            return View(MembersList);
        }
    }
}
