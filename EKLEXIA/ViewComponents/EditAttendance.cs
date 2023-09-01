
using EKLEXIA.Data;
using EKLEXIA.DataProtection;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EKLEXIA.ViewComponents
{
    public class EditAttendance : ViewComponent
    {
        public readonly XContext xct;
        public EditAttendance(XContext XContext)
        {
            xct = XContext;
        }


        //private List<MemberListVM> LoadMemberList()
        //{
        //    List<MemberListVM> csf = new();
        //    csf = xct.Members.Select(u => new MemberListVM
        //    {
        //        //ReferenceRange=u.ReferenceRange,
        //        //ResultsName=u.Resultname,
        //        //Unit=u.Units,

        //    }).ToList();
        //    return csf;
        //}

        public IViewComponentResult Invoke(string Id)
        {
         var   attendanceToEdit=xct.Attendances.Include("Member").Include("Meeting").Where( a=>a.AttendanceId.Equals(Encryption.Decrypt(Id))).FirstOrDefault();


            EditAttendanceVM editAttendanceVM = new()
            {
       
                AttendanceId = attendanceToEdit.AttendanceId,
                MeetingId = attendanceToEdit.Meeting.Name,
                MemberId=attendanceToEdit.Member.Fullname,
                Date = attendanceToEdit.Date,
                Description = attendanceToEdit.Description,
                IsPresent=attendanceToEdit.IsPresent,   
            };
            return View(editAttendanceVM);
        }
    }
}
    


        

