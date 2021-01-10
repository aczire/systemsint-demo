using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WingtipToys.Models;

namespace WingtipToys.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var ProfileImage = "";

            Boolean fileOK = false;
            String path = Server.MapPath("~/Catalog/Images/");
            if (UserProfileImage.HasFile)
            {
                String fileExtension = System.IO.Path.GetExtension(UserProfileImage.FileName).ToLower();
                String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                for (int i = 0; i < allowedExtensions.Length; i++)
                {
                    if (fileExtension == allowedExtensions[i])
                    {
                        fileOK = true;
                    }
                }
            }

            if (fileOK)
            {
                try
                {
                    // Save to Images folder.
                    UserProfileImage.PostedFile.SaveAs(path + UserProfileImage.FileName);
                    // Save to Images/Thumbs folder.
                    UserProfileImage.PostedFile.SaveAs(path + "Thumbs/" + UserProfileImage.FileName);
                    ProfileImage = UserProfileImage.FileName;
                }
                catch (Exception ex)
                {
                    ErrorMessage.Text = ex.Message;
                }
            }
            else
            {
                ProfileImage = UserProfileImage.FileName;
            }

            var user = new User() { UserName = Email.Text, Email = Email.Text, FirstName = FirstName.Text, LastName = LastName.Text, ImagePath = ProfileImage, LastLoginDate = DateTimeOffset.MinValue };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}
