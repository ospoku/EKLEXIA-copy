using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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



        public async Task<IActionResult> AddMember(AddMemberVM addMemberVM, IFormFile Photo)
        {
            if (!ModelState.IsValid)
            {


                return ViewComponent("AddMember");
            }

            if (ModelState.IsValid)
            {
                //  if (imageData != null && imageData.Length > 0) 

                int membershipid = cxt.Members.Count() + 1;
                string memberId = "JWC" + membershipid.ToString();
                int length = membershipid.ToString().Length;

                if (length == 1) { memberId = "JWC00" + membershipid.ToString(); }
                if (length == 2) { memberId = "JWC0" + membershipid.ToString(); }
                if (length == 3) { memberId = "JWC" + membershipid.ToString(); }


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
                    GroupId = addMemberVM.GroupId,
                    BranchId = addMemberVM.BranchId,
                    CareerId = addMemberVM.CareerId,
                    IDNumber = memberId,
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




                //we creating the necessary URL string:
                string GeneratedID = (from m in cxt.Members where m.MemberId == addThisMember.MemberId select m.IDNumber).FirstOrDefault().ToString()
                       ;
                string URL = "https://frog.wigal.com.gh/ismsweb/sendmsg?";
                string from = "JHC";
                string username = "KofiPoku";
                string password = "Az36400@osp";
                string to = addThisMember.Telephone;
                string messageText = "Thank you for joining Joy House Chapel. Your church ID is" + GeneratedID + "You are Welcome";

                // Creating URL to send sms
                string message = URL
                    + "username="
                    + username
                    + "&password="
                    + password
                    + "&from="
                    + from
                    + "&to="
                    + to
                    + "&service="
                    + "SMS"
                    + "&message="
                    + messageText;



                HttpClient httpclient = new();

                var response2 = await httpclient.SendAsync(new HttpRequestMessage(HttpMethod.Post, message));
                if (response2.StatusCode == HttpStatusCode.OK)
                {
                    // Do something with response. Example get content:
                    // var responseContent = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
                }


                TempData["Message"] = "New Member successfully added";

                return RedirectToAction("ViewMembers");
            }
            else
            {
                ViewBag.Message = "Member creation error!!! Please try again";
            }
            return ViewComponent("AddMember");
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
        public IActionResult ViewMembers()
        {
            return ViewComponent("ViewMembers");
        }

        public IActionResult DeleteMember() => ViewComponent("ViewMembers");

        public IActionResult ViewCardList()
        {
            return ViewComponent("ViewCardList");
        }
        public IActionResult Card(string Id)
        {
            return ViewComponent("Card", Id);
        }






    }
}
