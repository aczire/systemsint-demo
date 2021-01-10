using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using System.Web.ModelBinding;
using System.Web.Routing;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;

namespace WingtipToys
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<User> GetProducts()
        {
            var _db = new WingtipToys.Models.ApplicationDbContext();

            IQueryable<User> query = _db.Users;

            if (Context.User.IsInRole("admin"))
            {
                return query;
            }

            if (Context.User.IsInRole("manager"))
            {
                var currentUser = Context.User.Identity.GetUserId();
                query = query.Where(u => u.ManagerId == currentUser);
            }
            else
            {
                var currentUser = Context.User.Identity.GetUserId();
                query = query.Where(u => u.Id == currentUser);
            }

            return query;
        }
    }
}