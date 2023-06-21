
using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

namespace EKLEXIA.ViewComponents
{
    public class Dashboard:ViewComponent
    {
        public readonly XContext xct;
        public Dashboard(XContext XContext)
        {
            xct = XContext;
        }

        public IViewComponentResult Invoke()

        {
            DashboardVM viewDashboardVM = new()
            {
                TotalMembers = xct.Members.Where(a => a.IsDeleted == false).Count().ToString(),
                TotalFemales=xct.Members.Where(a=>a.IsDeleted==false&a.Gender.Name=="Female").Count().ToString(),
                TotalMales = xct.Members.Where(a => a.IsDeleted == false & a.Gender.Name == "Male").Count().ToString(),
           
            };
        return View(viewDashboardVM);
           
        }
    }
}
