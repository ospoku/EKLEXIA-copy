
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class Fundraisings : ViewComponent
    {
        public readonly XContext xct;
        public Fundraisings(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var IncomesList = xct.Incomes.Where(i => i.IsDeleted == false).Select(i => new IncomesVM
            {
               





            }).ToList();
            return View(IncomesList);
        }
    }
}
