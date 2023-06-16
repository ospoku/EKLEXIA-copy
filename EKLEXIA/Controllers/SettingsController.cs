
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

namespace ECLEXIA.Controllers
{
    public class SettingsController : Controller
    {
        public readonly XContext xct;
        public readonly UserManager<User> usm;
        public readonly RoleManager<Role> rol;
        public readonly SignInManager<User> sim;
        public readonly IWebHostEnvironment env;
        public SettingsController(XContext xContext, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signinmanager, IWebHostEnvironment environment)
        {
            usm = userManager;
            xct = xContext;
            rol = roleManager;
            sim = signinmanager;
            env = environment;
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
                Career addThisCareer = new Career
                {
                    Name = addCareerVM.Name,
                    Description = addCareerVM.Description,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                    CreatedDate = DateTime.Now,
                };

                xct.Careers.Add(addThisCareer);
                await xct.SaveChangesAsync();
                TempData["Message"] = "New Member successfully added";
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
        public IActionResult AddGroup()
        {



            return ViewComponent("AddGroup");
        }
        [HttpPost]
        public async Task<IActionResult> AddGroup(AddGroupVM addGroupVM)
        {
            if (ModelState.IsValid)
            {
                Group addThisGroup = new Group
                {
                    Name = addGroupVM.Name,
                    Description = addGroupVM.Description,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                    CreatedDate = DateTime.Now,
                };

                xct.Groups.Add(addThisGroup);
                await xct.SaveChangesAsync();
                TempData["Message"] = "New Group successfully added";
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

        public IActionResult Branches()
        {
            return ViewComponent("Branches");
        }

        [HttpGet]
        public IActionResult AddBranch()
        {
            return ViewComponent("AddBranch");
        }
        [HttpPost]
        public async Task<IActionResult> AddBranch(AddBranchVM addBranchVM)
        {
            if (ModelState.IsValid)
            {
                Branch addThisBranch = new Branch
                {
                    Name = addBranchVM.Name,
                    Description = addBranchVM.Description,
                    CreatedBy = User.Claims.FirstOrDefault(c => c.Type == "Name").Value,
                    CreatedDate = DateTime.Now,
                };

                xct.Branches.Add(addThisBranch);
                await xct.SaveChangesAsync();
                TempData["Message"] = "New Branch successfully added";
                return RedirectToAction("Branches");
            }


            else
            {
                ViewBag.Message = "Branch creation error!!! Please try again";
            }
            return ViewComponent("AddBranch");
        }

    }
}