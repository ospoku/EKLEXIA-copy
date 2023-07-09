﻿using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EKLEXIA.Controllers
{

    public class MemberController : Controller
    {

        public readonly XContext cxt;
     

     
        public MemberController(XContext xContext)
        {
            cxt = xContext;
         
           
        }

        [HttpGet]
        public IActionResult AddMember() => ViewComponent("AddMember");

        private static byte[] ConvertToBytes(IFormFile file)
        {

            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            };


        }


        [HttpPost]
        public async Task<IActionResult> AddMember(AddMemberVM addMemberVM, IFormFile Photo)
        {
                Member addThisMember = new()
                {
                    Address = addMemberVM.Address,
                    DoB = addMemberVM.DoB,
                    GenderId = addMemberVM.GenderId,
                    Othername = addMemberVM.Othername,
                    Telephone = addMemberVM.Telephone,
                    Hometown = addMemberVM.Hometown,
                    Surname = addMemberVM.Surname,
                    RegionId = addMemberVM.RegionId,
                  
                    BranchId = addMemberVM.BranchId,
                    CareerId = addMemberVM.CareerId,
                    IDNumber = "memberId",
                    IsDeleted = false,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                    CreatedDate = DateTime.Now
                };

                using (var memoryStream = new MemoryStream())
                {
                    await Photo.CopyToAsync(memoryStream);
                    addThisMember.Photo = memoryStream.ToArray();
                }



                cxt.Members.Add(addThisMember);

                await cxt.SaveChangesAsync();
       

            //var notification = new Data.Notification
            //{
            //Text=$"The"};

           

                return RedirectToAction("Members");
            }
       
          
        

        public IActionResult DetailMember(string Id)
      => ViewComponent("DetailMember", Id);
        public IActionResult EditMember(string Id)
        => ViewComponent("EditMember", Id);
        [HttpPost]
        public async Task<IActionResult> EditMemberAsync(string Id, Member member)
        {
            Member updateThisMember = new();
            updateThisMember = (from a in cxt.Members where a.MemberId == Id select a).FirstOrDefault();

            updateThisMember.Address = member.Address;

            updateThisMember.DoB = member.DoB;
            updateThisMember.Hometown = member.Hometown;
            updateThisMember.RegionId = member.RegionId;
            updateThisMember.Telephone = member.Telephone;
            updateThisMember.GenderId = member.GenderId;

            updateThisMember.Othername = member.Othername;

            updateThisMember.Surname = member.Surname;

            updateThisMember.IsDeleted = false;
            updateThisMember.ModifiedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value;
            updateThisMember.ModifiedDate = DateTime.Now;

            cxt.Members.Attach(updateThisMember);
            cxt.Entry(updateThisMember).State = EntityState.Modified;
            await cxt.SaveChangesAsync();

            return RedirectToAction("ViewMembers");
        }
        [HttpGet]
        public IActionResult Members()
        {
            return ViewComponent("Members");
        }
        [HttpGet]
        public IActionResult Birthdays()
        {
            return ViewComponent("Birthdays");
        }
       

        public IActionResult IDCards()
        {
            return ViewComponent("IDCards");
        }
        [HttpGet]
        public IActionResult Card(string Id)
        {
            return ViewComponent("Card", Id);
        }






    }
}
