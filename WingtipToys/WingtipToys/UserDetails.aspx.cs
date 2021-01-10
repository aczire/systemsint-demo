using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using System.Web.ModelBinding;
using Microsoft.AspNet.Identity;

namespace WingtipToys
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<User> GetProduct(
                            [QueryString("ProductID")] string productId,
                            [RouteData] string id)
        {

            //TODO: Check whether the current user has privillege to see the requested user.
            // var isAdmin = Context.User.IsInRole("admin");
            // var currUser = Context.User.Identity.GetUserId();

            var _db = new WingtipToys.Models.ApplicationDbContext();
            IQueryable<User> user = _db.Users;
            if (!String.IsNullOrWhiteSpace(productId))
            {
                user = user.Where(p => p.Id == productId);
            }
            else if (!String.IsNullOrEmpty(id))
            {
                user = user.Where(p =>
                  String.Compare(p.Id, id) == 0);
            }
            else
            {
                user = null;
            }

            return user;
        }

        public string GetManager(string managerId)
        {
            if (!String.IsNullOrWhiteSpace(managerId))
            {
                var _db = new WingtipToys.Models.ApplicationDbContext();
                IQueryable<User> user = _db.Users.Where(u => u.Id == managerId);
                return user.FirstOrDefault().Email;
            }
            else
            {
                return "";
            }
        }
    }
}