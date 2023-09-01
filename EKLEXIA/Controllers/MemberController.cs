using EKLEXIA.Models;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspNetCoreHero.ToastNotification.Abstractions;
using System.Net;
using EKLEXIA.Notice;
using Microsoft.AspNetCore.SignalR;
using EKLEXIA.DataProtection;

namespace EKLEXIA.Controllers
{

    public class MemberController : Controller
    {

        public readonly XContext ctx;

        private readonly INotyfService notyf;
        public readonly IHubContext<NotificationHub> hCtx;
        public MemberController(XContext xContext, INotyfService tNotyf, IHubContext<NotificationHub> hubContext)
        {
            ctx = xContext;
            notyf = tNotyf;
            hCtx = hubContext;

        }

        [HttpGet]
        public IActionResult AddMember() => ViewComponent("AddMember");

        //private static byte[] ConvertToBytes(IFormFile file)
        //{

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        file.CopyTo(memoryStream);
        //        return memoryStream.ToArray();
        //    };


        //}


        [HttpPost]
        public async Task<IActionResult> AddMember(AddMemberVM addMemberVM, IFormFile Photo)


        {

            int membershipid = ctx.Members.Count() + 1;
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



            ctx.Members.Add(addThisMember);
            await ctx.SaveChangesAsync();
            notyf.Success("member successfully created.");
            await hCtx.Clients.All.SendAsync("ReceiveNotification", $"New Post Created: {addThisMember.Fullname}");
            return RedirectToAction("Members");




        }

        public async Task<IActionResult> SendSMS()
        {
            Member member = new();

            //we creating the necessary URL string:
            string GeneratedID = (from m in ctx.Members where m.MemberId == member.MemberId select m.IDNumber).FirstOrDefault().ToString()
                   ;
            string URL = "https://frog.wigal.com.gh/ismsweb/sendmsg?";
            string from = "JHC";
            string username = "KofiPoku";
            string password = "Az36400@osp";
            string to = member.Telephone;
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

            return RedirectToAction();

        }
        public async Task<IActionResult> Birthday()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DetailMember(string Id)
        {
            return ViewComponent("DetailMember", Id);
        }

        public IActionResult EditMember(string Id)
        => ViewComponent("EditMember", Id);
        [HttpPost]
        public async Task<IActionResult> EditMemberAsync(string Id, Member member)
        {
            Member updateThisMember = new();
            updateThisMember = (from a in ctx.Members where a.MemberId == Encryption.Decrypt(Id) select a).FirstOrDefault();

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

            ctx.Members.Attach(updateThisMember);
            ctx.Entry(updateThisMember).State = EntityState.Modified;

            await ctx.SaveChangesAsync();
            notyf.Success("Member successfully updated");
            return RedirectToAction("Members");
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


        public IActionResult Delete(string Id)

        {



        }
    }
}