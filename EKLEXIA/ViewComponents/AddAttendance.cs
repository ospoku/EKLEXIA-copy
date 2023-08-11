
using EKLEXIA.Data;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using static EKLEXIA.ViewComponents.AddAttendance;

namespace EKLEXIA.ViewComponents
{
    public class AddAttendance : ViewComponent
    {
        public readonly XContext xct;
        public AddAttendance(XContext XContext)
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

        public IViewComponentResult Invoke()
        {
            AddAttendanceVM AddAttendanceVM = new();

            {
                AddAttendanceVM.Meetings = new SelectList(xct.Meetings.ToList(), nameof(Meeting.MeetingId), nameof(Meeting.Name));

                AddAttendanceVM.Attendees = xct.Members.Select(m => new CheckBoxItem

                {
                    Name = m.Fullname,
                    Value = m.MemberId,
                    
                }
                
                
                ).ToList();
             
            }
            return View(AddAttendanceVM);
        }
    }
}
    


        

