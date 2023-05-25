using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace EKLEXIA.ViewComponents
{
    public class ViewWelfares : ViewComponent
    {
        public readonly XContext xct;
        public ViewWelfares(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var IncomesList = xct.Welfares.Where(i => i.IsDeleted == false).Select(i => new ViewWelfaresVM
            {






            }).ToList();
            return View(IncomesList);
        }
    }
}
