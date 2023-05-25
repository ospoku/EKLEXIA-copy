using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class AddIncome : ViewComponent
    {
        public readonly XContext xct;
        public AddIncome(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            AddIncomeVM addIncomeVM = new AddIncomeVM
            {



            };

            return View(addIncomeVM);
        }

    }
}
