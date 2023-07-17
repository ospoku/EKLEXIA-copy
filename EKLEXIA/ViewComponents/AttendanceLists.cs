
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
            List<AttendanceListsVM> attendanceLists = xct.AttendanceLists.Where(i => i.IsDeleted == false).Select(i => new AttendanceListsVM
            {
               





            }).ToList();
            return View(attendanceLists);
        }
    }
}
