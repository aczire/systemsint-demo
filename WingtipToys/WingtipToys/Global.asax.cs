using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Data.Entity;
using WingtipToys.Models;
using WingtipToys.Logic;

namespace WingtipToys
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Setup the Service Configuration
            ServerConfig.RegisterConfig("development");

            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Create the custom role and user.
            RoleActions roleActions = new RoleActions();
            roleActions.AddUserAndRole();

            UsersDatabaseInitializer defaultUsers = new UsersDatabaseInitializer();
            defaultUsers.Seed();

            // Add Routes.
            RegisterCustomRoutes(RouteTable.Routes);
        }

        void RegisterCustomRoutes(RouteCollection routes)
        {
          routes.MapPageRoute(
              "ProductByNameRoute",
              "Product/{id}",
              "~/ProductDetails.aspx"
          );
        }

        void Application_Error(object sender, EventArgs e)
        {
          // Code that runs when an unhandled error occurs.

          //// Get last error from the server
          //Exception exc = Server.GetLastError();

          //if (exc is HttpUnhandledException)
          //{
          //  if (exc.InnerException != null)
          //  {
          //    exc = new Exception(exc.InnerException.Message);
          //    Server.Transfer("ErrorPage.aspx?handler=Application_Error%20-%20Global.asax",
          //        true);
          //  }
          //}
        }
    }
}