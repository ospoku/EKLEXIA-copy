using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class Careers : ViewComponent
    {
        public readonly XContext xct;
        public Careers(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var Careers = xct.Careers.Where(c => c.IsDeleted == false).Select(c => new CareersVM
            {
               CareerName =c.Name,

                CareerId = c.Id



            }).ToList();
            return View(Careers);
        }
    }
}
