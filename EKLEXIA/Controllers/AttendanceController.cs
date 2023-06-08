using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EKLEXIA.Controllers
{
    public class AttendanceController : Controller
    {

        public readonly XContext cxt;


        public AttendanceController(XContext xContext)
        {
            cxt = xContext;

        }

        [HttpGet]
        public IActionResult AddMeeting() => ViewComponent("AddMeeting");

        [HttpGet]
        public IActionResult AddAttendance() => ViewComponent("AddAttendance");
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
                    //Description = addMeetingVM.Description,
                    IsDeleted = false,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                    CreatedDate = DateTime.Now
                };
                cxt.Meetings.Add(addThisMeeting);
                await cxt.SaveChangesAsync();
                TempData["Message"] = "New Member successfully added";
                return RedirectToAction("Meetings");
            }
            else
            {
                ViewBag.Message = "Member creation error!!! Please try again";
            }
            return ViewComponent("AddMeeting");
        }

        public IActionResult DetailMeeting(string Id)
      => ViewComponent("DetailMember", Id);
        public IActionResult EditMeeting(string Id)
        => ViewComponent("EditMember", Id);
        [HttpPost]
        public async Task<IActionResult> EditMeetingAsync(string Id, Meeting meeting)
        {
            Meeting updateThisMeeting = new();
            updateThisMeeting = (from a in cxt.Meetings where a.Id == Id select a).FirstOrDefault();

            updateThisMeeting.Name = meeting.Name;

     
            updateThisMeeting.IsDeleted = false;
            updateThisMeeting.ModifiedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value;
            updateThisMeeting.ModifiedDate = DateTime.Now;

            cxt.Meetings.Attach(updateThisMeeting);
            cxt.Entry(updateThisMeeting).State = EntityState.Modified;
            await cxt.SaveChangesAsync();

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
