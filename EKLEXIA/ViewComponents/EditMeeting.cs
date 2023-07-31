using Microsoft.AspNetCore.Mvc;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;

using EKLEXIA.DataProtection;

namespace EKLEXIA.ViewComponents
{
    public class EditMeeting : ViewComponent
    {
        public readonly XContext xct;
        
        public EditMeeting(XContext xContext)
        {
            xct = xContext;
         
        }
        public IViewComponentResult Invoke(string Id)
        {
         
           
             var meetingToEdit= xct.Meetings.Where(c => c.MeetingId == Encryption.Decrypt(Id)).FirstOrDefault();
            EditMeetingVM editMeetingVM = new()
            {

                MeetingId=meetingToEdit.MeetingId,

                Name = meetingToEdit.Name,
            
              
            Description=meetingToEdit.Description
       

            };
            return View(editMeetingVM);
        }
    }
}
