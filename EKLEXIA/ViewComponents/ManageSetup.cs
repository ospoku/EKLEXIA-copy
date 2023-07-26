using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class ManageSetup : ViewComponent
    {
        public readonly XContext xct;
        public ManageSetup(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            SetupVM setupVM = new()
            {

            };

            return View(setupVM);
        }

    }
}
