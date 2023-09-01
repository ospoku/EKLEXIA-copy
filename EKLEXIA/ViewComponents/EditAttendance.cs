using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EKLEXIA.Data;
using EKLEXIA.Models;
using EKLEXIA.ViewModels;
using System.Diagnostics.CodeAnalysis;
using EKLEXIA.DataProtection;

namespace EKLEXIA.ViewComponents
{
    public class EditAttendance : ViewComponent
    {
        public readonly XContext xct;
        [SetsRequiredMembers]
        public EditAttendance(XContext XContext)
        {
            xct = XContext;
        }
        public IViewComponentResult Invoke(string Id)
        {
           Attendance attendanceToEdit = new();
            attendanceToEdit = (from a in xct.Attendances where a.AttendanceId == Encryption.Decrypt(Id) & a.IsDeleted == false select a).FirstOrDefault();
            EditAttendanceVM editMemberVM = new()
            {
             
                
           Meetings = new SelectList(xct.Meetings.ToList(),nameof(Meeting.MeetingId),nameof(Meeting.Name)),    
        
           Date=attendanceToEdit.Date,
           Description=attendanceToEdit.Description,
           IsPresent=attendanceToEdit.IsPresent,
           MeetingId=attendanceToEdit.MeetingId,
           MemberId=    attendanceToEdit.MemberId,
            };
            return View(editMemberVM);
        }
    }
}
