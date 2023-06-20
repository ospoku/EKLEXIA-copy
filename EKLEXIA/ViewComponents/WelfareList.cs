using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace EKLEXIA.ViewComponents
{
    public class WelfareList : ViewComponent
    {
        public readonly XContext xct;
        public WelfareList(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var IncomesList = xct.Welfares.Where(i => i.IsDeleted == false).Select(i => new WelfaresVM
            {






            }).ToList();
            return View(IncomesList);
        }
    }
}
