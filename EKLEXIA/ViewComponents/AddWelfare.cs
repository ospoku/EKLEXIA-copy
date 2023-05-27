using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using EKLEXIA.Models;

namespace EKLEXIA.ViewComponents
{
    public class AddWelfare:ViewComponent
    {
        public readonly XContext xct;
        public AddWelfare(XContext XContext)
        {
            xct = XContext;
        }

        public IViewComponentResult Invoke()
        {
            AddWelfareVM addWelfareVM = new AddWelfareVM
            {
                Members = new SelectList(xct.Members.ToList(), nameof(Member.MemberId), nameof(Member.Fullname)),
                Months = new SelectList(xct.Months.OrderByDescending(x => x.MonthId).ToList(), nameof(Month.MonthId), nameof(Month.Name)),

            };

            return View(addWelfareVM);
        }
            
    }
}
