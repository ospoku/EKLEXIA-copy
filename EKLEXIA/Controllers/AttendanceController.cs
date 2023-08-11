using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using EKLEXIA.DataProtection;

namespace EKLEXIA.Controllers
{
    public class AttendanceController : Controller
    {

        public readonly XContext xct;
        public readonly INotyfService notx;

        public AttendanceController(XContext xContext, INotyfService notyf)
        {
            xct = xContext;
            notx = notyf;
        }

        [HttpGet]
        public IActionResult AddMeeting() => ViewComponent("AddMeeting");

        [HttpGet]
        public IActionResult AddAttendance() => ViewComponent("AddAttendance");
        [HttpPost]
        public IActionResult AddAttendance(AddAttendanceVM addAttendanceVM)
        {
            foreach (var att in addAttendanceVM.Attendees)
            {


                Attendance addThisAttendance = new Attendance
                {
                    Date = addAttendanceVM.Date,
                    Description = att.Description,
                    MemberId = att.Value.ToString(),
                    MeetingId = addAttendanceVM.MeetingId,
                    IsPresent = att.IsSelected,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                    CreatedDate = DateTime.Now
                };

                xct.Attendances.Add(addThisAttendance);
            }
                xct.SaveChanges();
            


            return ViewComponent(nameof(AttendanceLists));
        }
        [HttpPost]
        public async Task<IActionResult> AddMeeting(AddMeetingVM addMeetingVM)
        {
            if (!ModelState.IsValid)
            {
                return ViewComponent("AddMeeting");
            }

            if (ModelState.IsValid)
            {
                Meeting addThisMeeting = new()
                {
                    Name = addMeetingVM.Name,
                    Description = addMeetingVM.Description,
                    
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                  
                    CreatedDate = DateTime.Now
                };
                xct.Meetings.Add(addThisMeeting);
                await xct.SaveChangesAsync();
                notx.Success("Meeting successful created");
                return ViewComponent("Meetings");
            }
            else
            {
                notx.Error( "Meeting creation error!!! Please try again");
            }
            return ViewComponent("AddMeeting");
        }

        public IActionResult DetailMeeting(string Id)
      => ViewComponent("DetailMember", Id);
        public IActionResult EditMeeting(string Id)
        => ViewComponent("EditMeeting", Id);
        [HttpPost]
        public async Task<IActionResult> EditMeetingAsync(string Id, EditMeetingVM editMeetingVM)
        {
            Meeting updateThisMeeting = new();
            updateThisMeeting = (from a in xct.Meetings where a.MeetingId == Encryption.Decrypt(Id) select a).FirstOrDefault();

            updateThisMeeting.Name = editMeetingVM.Name;

     
            updateThisMeeting.IsDeleted = false;
            updateThisMeeting.ModifiedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value;
            updateThisMeeting.ModifiedDate = DateTime.Now;

            xct.Meetings.Attach(updateThisMeeting);
            xct.Entry(updateThisMeeting).State = EntityState.Modified;
            await xct.SaveChangesAsync();

            return RedirectToAction("Meetings");
        }
        [HttpGet]
        public IActionResult Meetings()
        {
            return ViewComponent("Meetings");
        }

        public IActionResult DeleteMember() => ViewComponent("ViewMembers");

        public IActionResult AttendanceLists() => ViewComponent("AttendanceLists");





    }
}
