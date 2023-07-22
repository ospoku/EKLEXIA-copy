
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EKLEXIA.ViewComponents
{
    public class AttendanceLists : ViewComponent
    {
        public readonly XContext xct;
        public AttendanceLists(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke()
        {
            List<AttendanceListsVM> attendanceLists = xct.Attendances.Where(i => i.IsDeleted == false).Select(i => new AttendanceListsVM
            {
                Fullname=i.Member.Fullname,
                Date=i.Date,
                IsSelected=i.IsPresent,
                Meeting=i.Meeting.Name,
                Comment = i.Description,
               AttendanceId=i.AttendanceId,
                

                
            }).ToList();
            return View(attendanceLists);
        }
    }
}
