
using EKLEXIA.Models;
using EKLEXIA.Controllers;
using EKLEXIA.Data;
using EKLEXIA.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.DataProtection;
using EKLEXIA.ViewComponents;
using AspNetCoreHero.ToastNotification.Abstractions;
using EKLEXIA.DataProtection;
using Microsoft.EntityFrameworkCore;

namespace ECLEXIA.Controllers
{
    public class SettingsController : Controller
    {
        public readonly XContext ctx; 
        public readonly UserManager<User> usm;
        public readonly RoleManager<AppRole> rol;
        public readonly SignInManager<User> sim;
        public readonly IWebHostEnvironment env;
        public readonly INotyfService notyf;
        public SettingsController(XContext xContext, INotyfService tnotyf)
        {
            ctx = xContext;
            notyf = tnotyf;
        }
        
      


        [HttpGet]
        public IActionResult AddCareer()
        {

        

            return ViewComponent("AddCareer");
        }
        [HttpPost]
        public async Task<IActionResult> AddCareer(AddCareerVM addCareerVM)
        {
            if (ModelState.IsValid)
            {
                Career addThisCareer = new()
                {
                    Name = addCareerVM.Name,
                    Description = addCareerVM.Description,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                    CreatedDate = DateTime.Now,
                };

                ctx.Careers.Add(addThisCareer);
                await ctx.SaveChangesAsync();
                notyf.Success("New Career successfully created");
                return RedirectToAction("Careers");
            }


            else
            {
                ViewBag.Message = "Member creation error!!! Please try again";
            }
            return ViewComponent("AddCareer");
        }
public IActionResult Careers()
        {

            return ViewComponent("Careers");
        }
        [HttpGet]
        public IActionResult EditCareer(string Id)
        {
          
            return ViewComponent("EditCareer",Id);
        }
        [HttpGet]
        public IActionResult AddGroup()
        {



            return ViewComponent("AddGroup");
        }
        [HttpPost]
        public async Task<IActionResult> AddGroup(AddGroupVM addGroupVM)
        {
            if (ModelState.IsValid)
            {
                Group addThisGroup = new()
                {
                    Name = addGroupVM.Name,
                    Description = addGroupVM.Description,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                    CreatedDate = DateTime.Now,
                };

                ctx.Groups.Add(addThisGroup);
                await ctx.SaveChangesAsync();
                notyf.Success( "New Group successfully created");
                return RedirectToAction("Groups");
            }


            else
            {
                ViewBag.Message = "Member creation error!!! Please try again";
            }
            return ViewComponent("AddCareer");
        }
        public IActionResult Groups()
        {

            return ViewComponent("Groups");
        }
        public IActionResult Regions()
        {
            return ViewComponent("Regions");
        }
        public IActionResult Branches()
        {
            return ViewComponent("Branches");
        }

        [HttpGet]
        public IActionResult AddBranch()
        {
            return ViewComponent("AddBranch");
        }

        [HttpGet]
        public IActionResult ManageBranch(string Id)
        {
            return ViewComponent("ManageBranch",Id);
        }
        [HttpGet]
        public IActionResult Setup()
        {
            return ViewComponent("Setup");
        }
        [HttpGet]
        public IActionResult Preferences()
        {
            return ViewComponent("Preferences");
        }
        [HttpPost]
        public async Task<IActionResult> AddBranch(AddBranchVM addBranchVM)
        {
            if (ModelState.IsValid)
            {
                Branch addThisBranch = new()
                {
                    Name = addBranchVM.Name,
                    Description = addBranchVM.Description,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                    CreatedDate = DateTime.Now,
                };

                ctx.Branches.Add(addThisBranch);
                await ctx.SaveChangesAsync();
                notyf.Success("New Branch successfully created");
           
                return RedirectToAction("Branches");
            }


            else
            {
                ViewBag.Message = "Branch creation error!!! Please try again";
            }
            return ViewComponent("AddBranch");
        }

        [HttpGet]
        public IActionResult EditGroup(string Id)
        {
            return ViewComponent("EditGroup",Id);
        }

        [HttpPost]
        public async Task<IActionResult> EditGroup(string Id, EditGrpVM editGrpVM)
        {
         Group   grpToEdit = (from grp in ctx.Groups where grp.GroupId== Encryption.Decrypt(Id) select grp).FirstOrDefault();

       

            if(ModelState.IsValid)
            {
                grpToEdit.Name = editGrpVM.Name;
                grpToEdit.Description= editGrpVM.Description;
                grpToEdit.IsDeleted = false;
                grpToEdit.ModifiedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value;
                grpToEdit.ModifiedDate = DateTime.Now;

                ctx.Groups.Attach(grpToEdit);
                ctx.Entry(grpToEdit).State = EntityState.Modified;
                await ctx.SaveChangesAsync();
                notyf.Success("Group updated");
                return RedirectToAction("Groups");
            }
            else
            {

                notyf.Error("Update error, Please try again");
                return ViewComponent("EditGroup", Id);

            }

         
        }
        [HttpGet]
        public IActionResult ManageGroup(string Id)
        {
            return ViewComponent("ManageGroup", Id);
        }
        [HttpPost]
        public IActionResult ManageGroup(ManageGrpVM manageGrpVM, string Id)
        {

            foreach(var removeMembers in ctx.MemberGroups.Where(x=>x.GroupId.Equals(Encryption.Decrypt(Id))))
                    {
                ctx.MemberGroups.Remove(removeMembers);
            }

            foreach (var member in manageGrpVM.Members .Where(m => m.Selected == true).ToList())

            {
                ctx.MemberGroups.Add(new MemberGroup
                {
                    MemberId = member.Value,
                    GroupId = Encryption.Decrypt(Id),
                });
            }

            ctx.SaveChanges();
            notyf.Success("Group Members updated");
            return ViewComponent("Groups");

        }
    }
}