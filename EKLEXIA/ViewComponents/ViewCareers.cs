using EKLEXIA.Data;
using Microsoft.AspNetCore.Mvc;

namespace EKKLESIA.ViewComponents
{
    public class ViewCareers : ViewComponent
    {
        public readonly XContext xct;
        public ViewCareers(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var Careers = xct.Careers.Where(c => c.IsDeleted == false).Select(c => new ViewCareersVM
            {
               CareerName =c.Name,

                CareerId = c.Id



            }).ToList();
            return View(Careers);
        }
    }
}
