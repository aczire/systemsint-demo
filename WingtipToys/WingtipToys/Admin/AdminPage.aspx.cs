using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using WingtipToys.Logic;
using Microsoft.AspNet.Identity;

namespace WingtipToys.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string productAction = Request.QueryString["ProductAction"];
            if (productAction == "add")
            {
                LabelAddStatus.Text = "User updated!";
            }

            if (productAction == "remove")
            {
                LabelRemoveStatus.Text = "User removed!";
            }
        }

        public IQueryable GetProducts()
        {
            var _db = new WingtipToys.Models.ApplicationDbContext();
            String currentUser = HttpContext.Current.User.Identity.GetUserId();
            IQueryable<User> query = _db.Users.Where(u => u.Id != currentUser);
            return query;
        }

        public IQueryable GetApplicationUsers()
        {
            var _db = new WingtipToys.Models.ApplicationDbContext();
            String currentUser = HttpContext.Current.User.Identity.GetUserId(); //Context.User.Identity.GetUserName()
            IQueryable<User> query = _db.Users.Where(u => (u.Id != currentUser) && u.Manager != true);
            return query;
        }

        public IQueryable GetManagers()
        {
            var _db = new WingtipToys.Models.ApplicationDbContext();
            String currentUser = HttpContext.Current.User.Identity.GetUserId();
            IQueryable<User> query = _db.Users.Where(u => (u.Id != currentUser) && u.Manager == true);
            return query;
        }

        protected void AssignManagerButton_Click(object sender, EventArgs e)
        {
            // Add product data to DB.
            UpdateManager products = new UpdateManager();
            bool addSuccess = products.UpdateManagerId(UserEmail.Text, ManagerEmail.Text);
            if (addSuccess)
            {
                // Reload the page.
                string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                Response.Redirect(pageUrl + "?ProductAction=add");
            }
            else
            {
                LabelAddStatus.Text = "Unable to assign manager to user!.";
            }
        }

        protected void RemoveUserButton_Click(object sender, EventArgs e)
        {
            using (var _db = new WingtipToys.Models.ApplicationDbContext())
            {
                var productId = DropDownRemoveProduct.SelectedValue;
                var myItem = (from c in _db.Users where c.UserName == productId select c).FirstOrDefault();
                if (myItem != null)
                {
                    _db.Users.Remove(myItem);
                    _db.SaveChanges();

                    // Reload the page.
                    string pageUrl = Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.Count() - Request.Url.Query.Count());
                    Response.Redirect(pageUrl + "?ProductAction=remove");
                }
                else
                {
                    LabelRemoveStatus.Text = "Unable to locate user.";
                }
            }
        }
    }
}