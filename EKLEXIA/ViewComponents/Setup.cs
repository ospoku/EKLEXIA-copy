using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class Setup : ViewComponent
    {
        public readonly XContext xct;
        public Setup(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            SetupVM setupVM = new SetupVM
            {

            };

            return View(setupVM);
        }

    }
}
