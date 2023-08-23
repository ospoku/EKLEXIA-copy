using EKLEXIA.Data;
using EKLEXIA.DataProtection;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EKLEXIA.ViewComponents
{
    public class DetailMember:ViewComponent
    {
        public readonly XContext xct;
        public DetailMember(XContext XContext)
        {
            xct = XContext;
        }

        public IViewComponentResult Invoke(string Id)
        {
            var memberDetail = xct.Members.Where(a => a.MemberId == Encryption.Decrypt(Id)).FirstOrDefault();

            DetailMemberVM detailMemberVM = new()
            {


                Othername = memberDetail.Othername,

                Surname = memberDetail.Surname,
               
                
            };

           return View(detailMemberVM);
        }

    }
}
