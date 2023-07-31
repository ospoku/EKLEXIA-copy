using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
namespace EKLEXIA.ViewComponents
{
    public class Meetings : ViewComponent
    {
        public readonly XContext xct;
        public Meetings(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            var Meetings = xct.Meetings.Where(t => t.IsDeleted == false).Select(t => new MeetingsVM
            {

                Name=t.Name,
                Description = t.Description,
                MeetingId=t.MeetingId,



            }).ToList();
            return View(Meetings);
        }
    }
}
