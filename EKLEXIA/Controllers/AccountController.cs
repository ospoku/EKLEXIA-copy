
using ECLEXIA.Data;
using ECLEXIA.Models;
using ECLEXIA.ViewModels;
using JWHC.Controllers;
using JWHC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ECLEXIA.Controllers
{
    public class AccountController : Controller
    {
        public readonly XContext jwx;
        public readonly UserManager<User> usm;
        public readonly RoleManager<Role> rol;
        public readonly SignInManager<User> sim;
        public readonly IWebHostEnvironment env;
        public AccountController(XContext jwContext, UserManager<User> userManager, RoleManager<Role> roleManager, SignInManager<User> signinmanager, IWebHostEnvironment environment)
        {
            usm = userManager;
            jwx = jwContext;
            rol = roleManager;
            sim = signinmanager;
            env = environment;
        }
        [HttpGet]
        public IActionResult AddUser()
        {
            return ViewComponent("AddUser");
        }




        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserVM addUserVM)
        {



            if (ModelState.IsValid)
            {
                User addThisUser = new()
                {

                    UserName = addUserVM.Username,
                    Email = addUserVM.Email,
                    PhoneNumber = addUserVM.Telephone,
                    Firstname = addUserVM.Firstname,
                    Surname = addUserVM.Surname,
                };
                IdentityResult result = await usm.CreateAsync(addThisUser, addUserVM.Password);
                if (result.Succeeded)
                {
                    Role applicationRole = await rol.FindByIdAsync(addUserVM.ApplicationRoleId);
                    if (applicationRole == null)
                    {
                    }
                    else
                    {
                        await usm.AddToRoleAsync(addThisUser, applicationRole.Rolename);

                    }
                    ViewBag.Message = "New User created";


                    string ctoken = usm.GenerateEmailConfirmationTokenAsync(addThisUser).Result;
                    string ctokenLink = Url.Action(nameof(VerifyEmail), "Account", new { userId = addThisUser.Id, token = ctoken }, Request.Scheme);

                    using (MailMessage mailMessage = new())
                    {

                        mailMessage.Subject = "EMAIL VERIFICATION";
                        mailMessage.IsBodyHtml = true;
                        mailMessage.To.Add(addThisUser.Email);
                        mailMessage.From = new MailAddress("ospoku@gmail.com");
                        string body = string.Empty;
                        using (StreamReader reader = new(env.WebRootPath + Path.DirectorySeparatorChar.ToString()
                      + "Templates"
                            + Path.DirectorySeparatorChar.ToString()
                            + "EmailTemplate"
                            + Path.DirectorySeparatorChar.ToString()
                            + "EmailConfirmationTemplate.cshtml"))
                        {
                            body = reader.ReadToEnd();

                        };
                        body = body.Replace("{UserName}", addThisUser.UserName);
                        body = body.Replace("{url}", ctokenLink);
                        mailMessage.Body = body;
                        using (SmtpClient smtp = new())
                        {

                            smtp.Host = "smtp.gmail.com";
                            smtp.Port = 587;
                            smtp.Credentials = new NetworkCredential("ospoku@gmail.com", "az36400@osp");
                            smtp.EnableSsl = true;
                            smtp.Send(mailMessage);
                        };
                    }







                    //we creating the necessary URL string:
                    string URL = "https://frog.wigal.com.gh/ismsweb/sendmsg?";

                    string from = "JHC";
                    string username = "KofiPoku";
                    string password = "Az36400@osp";
                    string to = "233244139692";
                    string messageText = "Testing JHC Message Alerts";

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



                    ////we creating the necessary URL string:
                    //string URL = "https://frog.wigal.com.gh/api/v2/sendmsg";

                    //string username = "KofiPoku";
                    //string password = "Az36400@osp";

                    //string messageText = "Testing JHC Message Alerts";
                    //string destinations = "233244139692";
                    //string senderid = "JHC";
                    //// Creating URL to send sms
                    //string message = URL
                    //    + "username="
                    //    + username
                    //    + "&password="
                    //    + password
                    //    + "&senderid="
                    //    + senderid
                    //    + "&destinations="
                    //    + destinations
                    //    + "&service="
                    //    + "SMS"
                    //    + "&message="
                    //    + messageText;


                    HttpClient httpclient = new();

                    var response2 = await httpclient.SendAsync(new HttpRequestMessage(HttpMethod.Post, message));
                    if (response2.StatusCode == HttpStatusCode.OK)
                    {
                        // Do something with response. Example get content:
                        // var responseContent = await response.Content.ReadAsStringAsync ().ConfigureAwait (false);
                    }
                    TempData["Message"] = "New User Created";

                    return RedirectToAction("ViewUsers");

                }

            }

            else
            {
                TempData["ResultMessage"] = "User creation error";
            }

            return RedirectToAction("AddUser");
        }
        [HttpGet]
        public IActionResult EditUser(string Id)
        {
            return ViewComponent("EditUser", Id);
        }

        public IActionResult DetailUser(string Id)
        {
            return ViewComponent("DetailUser", Id);
        }
        public IActionResult DeleteUser()
        {
            return ViewComponent("DeleteUser");
        }
        [HttpPost]
        public async Task<IActionResult> EditUserAsync(string Id, User user, EditUserVM editUserVM)
        {
            User searchUser = (from u in usm.Users where u.Id == Id select u).FirstOrDefault();
            if (searchUser != null)
            {

                searchUser.Email = user.Email;
                searchUser.Firstname = user.Firstname;
                searchUser.Surname = user.Surname;
                searchUser.PhoneNumber = user.PhoneNumber;

                searchUser.UserName = user.UserName;

                IdentityResult identityResult = await usm.UpdateAsync(searchUser);
                IdentityResult result = identityResult;
                if (result.Succeeded)
                {
                    string existingRole = usm.GetRolesAsync(searchUser).Result.SingleOrDefault();
                    string existingRoleId = rol.Roles.Single(r => r.Name == existingRole).Id;
                    if (existingRoleId != editUserVM.ApplicationRoleId)
                    {
                        IdentityResult roleResult = await usm.RemoveFromRoleAsync(searchUser, existingRole);
                        if (roleResult.Succeeded)
                        {
                            Role applicationRole = await rol.FindByIdAsync(editUserVM.ApplicationRoleId);
                            if (applicationRole != null)
                            {
                                IdentityResult newRoleResult = await usm.AddToRoleAsync(searchUser, applicationRole.Name);
                                if (newRoleResult.Succeeded)
                                {
                                    return RedirectToAction("ViewUsers");
                                }
                            }
                        }
                    }
                }
            }


            return View("ViewUsers");
        }

        public IActionResult ViewUsers()
        {
            return ViewComponent("ViewUsers");
        }
        public IActionResult ManageRoles(string userId)
        {

            return ViewComponent("ManageRoles", userId);
        }
        [HttpGet]
        public IActionResult Login(LoginVM loginVM)
        {
            return View(loginVM);
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {

                return View();


            };
            var user = await usm.FindByNameAsync(loginVM.Username);
            var result = await sim.PasswordSignInAsync(loginVM.Username, loginVM.Password, loginVM.RememberMe, false);
            if (result.Succeeded)
            {
                var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                userClaims.AddClaim(new Claim("Name", user.UserName));
                userClaims.AddClaim(new Claim("Email", user.Email));
                userClaims.AddClaim(new Claim("Firstname", user.Firstname));
                userClaims.AddClaim(new Claim("Surname", user.Surname));


                userClaims.AddClaim(new Claim(ClaimTypes.Role, string.Join(",", from p in jwx.UserRoles
                                                                                join role in jwx.Roles on p.RoleId equals role.Id
                                                                                where p.UserId == user.Id
                                                                                select role.Name.ToString())));
                //string.Join(",", from p in gcx.UserRoles
                //                 join role in gcx.Roles on p.RoleId equals role.Id
                //                 where p.UserId == user.Id
                //                 select role.Name.ToString())););
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userClaims), new AuthenticationProperties { IsPersistent = true });

                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            else
            {
                ViewBag.Message = "login error!";

                return View(loginVM);

            }

        }

        public async Task<IActionResult> Logout(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await usm.FindByNameAsync(loginVM.Username);
                if (user != null)
                {
                    await sim.PasswordSignInAsync(user, loginVM.Password, false, false);

                    var userClaims = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    userClaims.AddClaim(new Claim("Name", user.UserName));


                    userClaims.AddClaim(new Claim(ClaimTypes.Role, string.Join(",", from p in jwx.UserRoles
                                                                                    join role in jwx.Roles on p.RoleId equals role.Id
                                                                                    where p.UserId == user.Id
                                                                                    select role.Name.ToString())));




                    //string.Join(",", from p in jwx.UserRoles
                    //                 join role in jwx.Roles on p.RoleId equals role.Id
                    //                 where p.UserId == user.Id
                    //                 select role.Name.ToString())););
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userClaims), new AuthenticationProperties { IsPersistent = true });

                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }

            }


            return View();
        }
        public async Task<IActionResult> VerifyEmail(string userId, string token)
        {

            var user = await usm.FindByIdAsync(userId);
            await usm.ConfirmEmailAsync(user, token);

            return BadRequest();
        }
        public async Task<IActionResult> SendEmailConfirmation(string userId, string token)
        {

            User user = await usm.FindByIdAsync(userId);
            await usm.ConfirmEmailAsync(user, token);


            return BadRequest();
        }
        public async Task<IActionResult> SendTextMessage(string userId, string token)
        {

            var user = await usm.FindByIdAsync(userId);
            await usm.ConfirmEmailAsync(user, token);

            return BadRequest();
        }
    }
}