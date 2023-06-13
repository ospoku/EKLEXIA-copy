
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

    }
}