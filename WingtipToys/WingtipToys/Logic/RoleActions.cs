using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WingtipToys.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WingtipToys.Logic
{
  internal class RoleActions
  {
    internal void AddUserAndRole()
    {
            try
            {


                // Access the application context and create result variables.
                Models.ApplicationDbContext context = new ApplicationDbContext();
                IdentityResult IdRoleResult;
                IdentityResult IdUserResult;

                // Create a RoleStore object by using the ApplicationDbContext object. 
                // The RoleStore is only allowed to contain IdentityRole objects.
                var roleStore = new RoleStore<IdentityRole>(context);

                // Create a RoleManager object that is only allowed to contain IdentityRole objects.
                // When creating the RoleManager object, you pass in (as a parameter) a new RoleStore object. 
                var roleMgr = new RoleManager<IdentityRole>(roleStore);

                // Then, you create the "admin" role if it doesn't already exist.
                if (!roleMgr.RoleExists("admin"))
                {
                    IdRoleResult = roleMgr.Create(new IdentityRole { Name = "admin" });
                }

                // Then, you create the "manager" role if it doesn't already exist.
                if (!roleMgr.RoleExists("manager"))
                {
                    IdRoleResult = roleMgr.Create(new IdentityRole { Name = "manager" });
                }

                // Create a UserManager object based on the UserStore object and the ApplicationDbContext  
                // object. Note that you can create new objects and use them as parameters in
                // a single line of code, rather than using multiple lines of code, as you did
                // for the RoleManager object.
                var userMgr = new UserManager<User>(new UserStore<User>(context));
                var appUser = new User
                {
                    UserName = "admin_user@wingtiptoys.com",
                    Email = "admin_user@wingtiptoys.com",
                    FirstName = "Admin",
                    LastName = "(Global)",
                    ImagePath = "planepaper.png",
                    Manager = true,
                    LastLoginDate = DateTimeOffset.MinValue
                };
                IdUserResult = userMgr.Create(appUser, "Pa$$word1");

                // If the new "admin" user was successfully created, 
                // add the "admin" user to the "admin" role. 
                if (!userMgr.IsInRole(userMgr.FindByEmail("admin_user@wingtiptoys.com").Id, "admin"))
                {
                    IdUserResult = userMgr.AddToRole(userMgr.FindByEmail("admin_user@wingtiptoys.com").Id, "admin");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occured during Role Initialization with error: {ex.Message}");
            }
    }
  }
}