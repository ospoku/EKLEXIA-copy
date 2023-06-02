using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace EKLEXIA.ViewComponents
{
    public class ViewMeetings : ViewComponent
    {
        public readonly XContext xct;
        public ViewMeetings(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var Meetings = xct.Meetings.Where(t => t.IsDeleted == false).Select(t => new ViewMeetingsVM
            {
               





            }).ToList();
            return View(Meetings);
        }
    }
}
