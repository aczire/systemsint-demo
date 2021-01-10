using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WingtipToys.Models;

namespace WingtipToys.Logic
{
    public class UpdateManager
    {
        public bool UpdateManagerId(string Email, string ManagerEmail)
        {

            try
            {
                using (ApplicationDbContext _db = new ApplicationDbContext())
                {
                    var userMgr = new UserManager<User>(new UserStore<User>(_db));
                    var user = userMgr.FindByEmail(Email);
                    var userManager = userMgr.FindByEmail(ManagerEmail);
                    user.ManagerId = userManager.Id;
                    // Add product to DB.
                    _db.Users.AddOrUpdate(user);
                    _db.SaveChanges();
                }

                // Success.
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}