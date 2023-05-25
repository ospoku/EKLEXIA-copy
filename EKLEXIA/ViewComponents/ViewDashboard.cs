
using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;

namespace EKKLESIA.ViewComponents
{
    public class ViewDashboard:ViewComponent
    {
        public readonly XContext xct;
        public ViewDashboard(XContext XContext)
        {
            xct = XContext;
        }

        public IViewComponentResult Invoke()

        {
            ViewDashboardVM viewDashboardVM = new ViewDashboardVM()
            {
                TotalMembers = xct.Members.Where(a => a.IsDeleted == false).Count().ToString(),
                TotalFemales=xct.Members.Where(a=>a.IsDeleted==false&a.Gender.GenderName=="Female").Count().ToString(),
                TotalMales = xct.Members.Where(a => a.IsDeleted == false & a.Gender.GenderName == "Male").Count().ToString(),
           
            };
        return View(viewDashboardVM);
           
        }
    }
}
