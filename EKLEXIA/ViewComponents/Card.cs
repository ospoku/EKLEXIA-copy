using EKLEXIA.Data;
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
            var card = xct.Members.Where(a => a.MemberId == Id & a.IsDeleted == false).Select(a => new CardVM


            {

                Address = a.Address,
                GenderId = a.Gender.GenderName,


                DoB = a.DoB,


                Fullname = a.Fullname,


                Telephone = a.Telephone,

            }).FirstOrDefault();

            return View(card);
        }

    }
}
