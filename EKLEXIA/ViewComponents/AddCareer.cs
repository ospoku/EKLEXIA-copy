using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class AddCareer:ViewComponent
    {
        public readonly XContext xct;
        public AddCareer(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            AddCareerVM addCareerVM = new AddCareerVM
            {



            };

            return View(addCareerVM);
        }
            
    }
}
