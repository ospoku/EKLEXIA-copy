
using EKLEXIA.Data;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class ViewIncomes : ViewComponent
    {
        public readonly XContext xct;
        public ViewIncomes(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var IncomesList = xct.Incomes.Where(i => i.IsDeleted == false).Select(i => new ViewIncomesVM
            {
               





            }).ToList();
            return View(IncomesList);
        }
    }
}
