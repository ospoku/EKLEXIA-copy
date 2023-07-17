﻿using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EKLEXIA.Controllers
{
    public class AttendanceController : Controller
    {

        public readonly XContext xct;


        public AttendanceController(XContext xContext)
        {
            xct = xContext;

        }

        [HttpGet]
        public IActionResult AddMeeting() => ViewComponent("AddMeeting");

        [HttpGet]
        public IActionResult AddAttendance() => ViewComponent("AddAttendance");
        [HttpPost]
        public IActionResult AddAttendance(AddAttendanceVM addAttendanceVM)
        {
            foreach (var att in addAttendanceVM.Members)
            {


                Attendance addThisAttendance = new()
                {
                    Date = addAttendanceVM.Date,
                    Description = addAttendanceVM.Description,
                    MemberId = addAttendanceVM.MemberId,
                    MeetingId = addAttendanceVM.MeetingId,
                    IsPresent = addAttendanceVM.IsPresent,
                };
                xct.Attendances.Add(addThisAttendance);
                xct.SaveChanges();
            }


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
                    IsDeleted = false,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                   

                    CreatedDate = DateTime.Now
                };
                xct.Meetings.Add(addThisMeeting);
                await xct.SaveChangesAsync();
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
            updateThisMeeting = (from a in xct.Meetings where a.Id == Id select a).FirstOrDefault();

            updateThisMeeting.Name = meeting.Name;

     
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
