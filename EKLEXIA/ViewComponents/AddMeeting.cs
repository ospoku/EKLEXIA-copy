using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class AddMeeting:ViewComponent
    {
        public readonly XContext xct;
        public AddMeeting(XContext xContext)
        {
            xct = xContext;
        }

        public IViewComponentResult Invoke()
        {
            AddMeetingVM addMeetingVM = new()
            {
             
             
        
            };

            return View(addMeetingVM);
        }
            
    }
}
