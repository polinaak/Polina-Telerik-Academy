using HambergiteConquistador.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace HambergiteConquistador.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected bool CanRemoveExternalLogins
        {
            get;
            private set;
        }

        protected void Page_Load()
        {
            if (!IsPostBack)
            {
                // Determine the sections to render
                ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
                if (manager.HasLocalLogin(User.Identity.GetUserId())) 
                {
                    changePasswordHolder.Visible = true;
                    DisplayUserPicture(true);
                }
                else 
                {
                    setPassword.Visible = true;
                    changePasswordHolder.Visible = false;
                }
                CanRemoveExternalLogins = manager.GetLogins(User.Identity.GetUserId()).Count() > 1;

                // Render success message
                var message = Request.QueryString["m"];
                if (message != null) 
                {
                    // Strip the query string from action
                    Form.Action = ResolveUrl("~/Account/Manage");

                    SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : String.Empty;
                    successMessage.Visible = !String.IsNullOrEmpty(SuccessMessage);
                }
            }
        }

        private void DisplayUserPicture(bool allow)
        {
            var userId = User.Identity.GetUserId();
            ConquistadorEntities context = new ConquistadorEntities();
            var user = context.AspNetUsers.Find(userId);
            string picturePath = "~/Uploaded_Files/default.jpg";
            if (user != null)
            {
                string pic = user.ImagePath;
                if (pic != null)
                {
                    picturePath = pic;
                }
            }
            this.ImageProfile.ImageUrl = picturePath;
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                IPasswordManager manager = new IdentityManager(new IdentityStore()).Passwords;
                IdentityResult result = manager.ChangePassword(User.Identity.GetUserName(), CurrentPassword.Text, NewPassword.Text);
                if (result.Success) 
                {
                    Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else 
                {
                    AddErrors(result);
                }
            }
        }

        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Create the local login info and link the local account to the user
                ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
                IdentityResult result = manager.AddLocalLogin(User.Identity.GetUserId(), User.Identity.GetUserName(), password.Text);
                if (result.Success) 
                {
                    Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else 
                {
                    AddErrors(result);
                }
            }
        }

        public IEnumerable<IUserLogin> GetLogins()
        {
            ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
            var accounts = manager.GetLogins(User.Identity.GetUserId());
            CanRemoveExternalLogins = accounts.Count() > 1;
            return accounts;
        }

        public void RemoveLogin(string loginProvider, string providerKey)
        {
            ILoginManager manager = new IdentityManager(new IdentityStore()).Logins;
            var result = manager.RemoveLogin(User.Identity.GetUserId(), loginProvider, providerKey);
            var msg = result.Success
                ? "?m=RemoveLoginSuccess"
                : String.Empty;
            Response.Redirect("~/Account/Manage" + msg);
        }

        private void AddErrors(IdentityResult result) {
            foreach (var error in result.Errors) {
                ModelState.AddModelError("", error);
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (this.FileUploadPic.HasFile)
            {
                try
                {
                    if (FileUploadPic.PostedFile.ContentType == "image/jpeg")
                    {
                        //save to server
                        string file = Path.GetFileName(FileUploadPic.FileName);
                        string path = Server.MapPath("~/Uploaded_Files/") + file;
                        FileUploadPic.SaveAs(path);

                        //save to db
                        var userId = User.Identity.GetUserId();
                        ConquistadorEntities context = new ConquistadorEntities();
                        var user = context.AspNetUsers.Find(userId);
                        user.ImagePath = "~/Uploaded_Files/" + file;
                        context.SaveChanges();

                        Error_Handler_Control.ErrorSuccessNotifier.AddSuccessMessage("Upload status: File uploaded!");
                    }
                    else
                    {
                        Error_Handler_Control.ErrorSuccessNotifier.AddWarningMessage("Allowed file types: image/jpeg!");
                    }
                }
                catch (Exception ex)
                {
                    Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                }                
            }
        }
    }
}