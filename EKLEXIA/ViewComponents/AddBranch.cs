using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class AddBranch : ViewComponent
    {
        public readonly XContext xct;
        public AddBranch(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            AddBranchVM addBranchVM = new()
            {

            };

            return View(addBranchVM);
        }

    }
}


  
