using MajorPrjt.Web.Data;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using MajorPrjt.Web.Models;

namespace MajorPrjt.Web.Data
{
    // A singleton Class
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedIdentityRolesAsync(RoleManager<IdentityRole> rolemanager)
        {
            foreach (MyIdentityRoleNames rolename in Enum.GetValues(typeof(MyIdentityRoleNames)))
            {
                if (!await rolemanager.RoleExistsAsync(rolename.ToString()))
                {
                    await rolemanager.CreateAsync(
                        new IdentityRole { Name = rolename.ToString() });
                }
            }
        }

        public static async Task SeedIdentityUserAsync(UserManager<IdentityUser> usermanager)
        {
            IdentityUser user;

            user = await usermanager.FindByNameAsync("admin@forum.com");
            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = "admin@forum.com",
                    Email = "admin@forum.com",
                    EmailConfirmed = true
                };
                await usermanager.CreateAsync(user, password: "Admin#123");

                await usermanager.AddToRolesAsync(user, new string[] {
                    MyIdentityRoleNames.AppAdmin.ToString(),
                    MyIdentityRoleNames.AppUser.ToString()
                });
            }

            user = await usermanager.FindByNameAsync("user@forum.com");
            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = "user@forum.com",
                    Email = "user@forum.com",
                    EmailConfirmed = true
                };
                await usermanager.CreateAsync(user, password: "User@567");
                //await usermanager.AddToRolesAsync(user, new string[] {
                //    MyIdentityRoleNames.AppUser.ToString()
                //});
                await usermanager.AddToRoleAsync(user, MyIdentityRoleNames.AppUser.ToString());
            }
        }

    }
}
