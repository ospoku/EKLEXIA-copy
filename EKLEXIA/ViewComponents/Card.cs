using EKLEXIA.Data;
using EKLEXIA.DataProtection;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class Card : ViewComponent
    {
        public readonly XContext xct;
        public Card(XContext XContext)
        {
            xct = XContext;
        }

        public IViewComponentResult Invoke(string Id)
        {
            var card = xct.Members.Where(a => a.MemberId == @Encryption.Decrypt(Id) & a.IsDeleted == false).Select(a => new CardVM


            {

                Address = a.Address,
               
                Photo = a.Photo,

                DoB = a.DoB,

                Fullname = a.Fullname,

               MemberId=a.IDNumber,
                BranchId = a.Branch.Name,
             Telephone = a.Telephone,

            }).FirstOrDefault();

            return View(card);
        }

    }
}
