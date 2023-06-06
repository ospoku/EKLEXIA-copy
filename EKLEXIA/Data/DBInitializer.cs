using System;
using EKLEXIA.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.Extensions.DependencyInjection;

namespace EKLEXIA.Data
{
    public class DBInitializer
    {
        public readonly XContext xct;

        public DBInitializer(XContext xContext)

        {
            xct = xContext;

        }
        public async Task MonthSetup()
        {
            if (xct.Months.Any() == false)
            {
                xct.Months.AddRange(new Month { Name = "January" },
                                             new Month { Name = "February" },
                                             new Month { Name = "March" },
                                             new Month { Name = "April" },
                                             new Month { Name = "May" },

                                             new Month { Name = "June" },
                                             new Month { Name = "July" },
                                             new Month { Name = "August" },
                                             new Month { Name = "September" },
                                             new Month { Name = "October" },
                                             new Month { Name = "November" },
                                              new Month { Name = "December" });

                await xct.SaveChangesAsync();
            }
        }
        public async Task MaritalStatusSetup()
        {
            if (xct.MaritalStatuses.Any() == false)
            {
                xct.MaritalStatuses.AddRange(new MaritalStatus { Name = "Single" },
                                             new MaritalStatus { Name = "Married" },
                                             new MaritalStatus { Name = "Divorced" },
                                             new MaritalStatus { Name = "Widow" },
                                             new MaritalStatus { Name = "Widower" });

                await xct.SaveChangesAsync();
            }
        }
        public async Task GenderSetup()
        {
            if (xct.Genders.Any() == false)
            {
                xct.Genders.AddRange(new Gender { GenderName = "Male" },
                    new Gender { GenderName = "Female" });
                await xct.SaveChangesAsync();
            }
        }
        public async Task RoleCreation(IServiceProvider serviceProvider)
        {
            var rol = serviceProvider.GetRequiredService<RoleManager<Role>>();
            if (rol.Roles.Any() == false)
            {
                await rol.CreateAsync(new Role() { Name = "Basic" });
                await rol.CreateAsync(new Role() { Name = "Manager" });
                await rol.CreateAsync(new Role() { Name = "SuperAdmin" });
                await rol.CreateAsync(new Role() { Name = "Admin" });
            };




        }

        public async Task BranchSetup()
        {
            if (xct.Branches.Any() == false)
            {
                xct.Branches.AddRange(new Branch { Name = "Amomole Canada" },
                    new Branch { Name = "Agape" });
                await xct.SaveChangesAsync();
            }
        }
        public async Task GroupSetup()
        {
            if (xct.Groups.Any() == false)
            {
                xct.Groups.AddRange(new Group { Name = "Men's Fellowship" },
                    new Group { Name = "Choir" },
                    new Group { Name = "Youth" },
                    new Group { Name = "Women's Fellowship" },
                      new Group { Name = "Sunday School" });
                await xct.SaveChangesAsync();
            }
        }

        public async Task CareerSetup()
        {
            if (xct.Careers.Any() == false)
            {
                xct.Careers.AddRange(new Career { Name = "Trading" },
                    new Career { Name = "Teaching" },
                    new Career { Name = "Student" },
                    new Career { Name = "Unemployed" },
                      new Career { Name = "Dress Making" });
                await xct.SaveChangesAsync();
            }
        }
        public async Task RegionSetup()
        {
            if (xct.Regions.Any() == false)
            {
                xct.Regions.AddRange(new Region { Name = "Greater Accra" },
                    new Region { Name = "Ashanti" },
                    new Region { Name = "Central" },
                    new Region { Name = "Eastern" },
                    new Region { Name = "Bono" },
                    new Region { Name = "Western" },
                    new Region { Name = "Western North" }
               );
                await xct.SaveChangesAsync();
            }
        }

        private readonly List<Claim> claimlist = new List<Claim>()
            {

                new Claim(ClaimTypes.Name,"SuperAdmin"),
                new Claim(ClaimTypes.Email,"oseipoku@gmail.com"),
                new Claim(ClaimTypes.Role,"SuperAdmin")
            };
        IdentityResult identityResult;
        public async Task UserCreation(IServiceProvider serviceProvider)
        {
            var usm = serviceProvider.GetRequiredService<UserManager<User>>();
            if (await usm.FindByNameAsync("SuperAdmin") == null)
            {
                User superUser = new()
                {
                    UserName = "SuperAdmin",
                    Surname = "SuperAdmin",
                    Firstname = "SuperAdmin",
                    Email = "admin@gmail.com",
                    PhoneNumber = "0244139692",
                    EmailConfirmed = true,

                };

                identityResult = await usm.CreateAsync(superUser, "OSP@SuperAdmin12345");
                if (identityResult.Succeeded)
                {
                    await usm.AddToRoleAsync(superUser, "SuperAdmin");
                    await usm.AddClaimsAsync(superUser, claimlist);
                };

            }


        }
    }
};


