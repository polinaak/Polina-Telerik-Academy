using Error_Handler_Control;
using HambergiteConquistador.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador.Account
{
    public partial class ChangeUserPassword : System.Web.UI.Page
    {
        private const int ValidTimeForNewPasswordInHours = 3;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }


        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            ConquistadorEntities context = new ConquistadorEntities();
            var userName = this.Request.Params["userName"];

            var store = new IdentityManager(new IdentityStore()).Store;
            IdentityResult result = 
               store.Secrets.UpdateAsync("TestTest", "newpass", CancellationToken.None).Result;

            //IdentityResult result = 
            //    store.Secrets.UpdateAsync(userName, "newpass", CancellationToken.None).Result;
            //IdentityResult identityResult3 = await manager.SaveChangesIfSuccessful(identityResult2, cancellationToken);

           


            //var newPassword = this.TextBoxNewPassword.Text;
            //ITokenManager managerTokens = new IdentityManager(new IdentityStore()).Tokens;
           
            //IPasswordManager manager = new IdentityManager(new IdentityStore()).Passwords;
            //if (this.Session["AdminTokenId"] != null)
            //{
            //    DateTime utils = DateTime.Now.AddHours(ValidTimeForNewPasswordInHours);

            //    var idToken = (this.Session["AdminTokenId"] as string).Substring(10);
            //    var idTokenLen = idToken.Length;

            //    var result = manager.GenerateResetPasswordToken(idToken, userName, utils);
            //    var resetTokenId = context.AspNetTokens.FirstOrDefault(t => t.Value == userName).Id;

            //    if (result.Success)
            //    {
            //       var tokenFromMan =  managerTokens.Find("", true).Id;

            //       var isPassReset = manager.ResetPassword("","");



            //        if (isPassReset.Success)
            //        {
            //            ErrorSuccessNotifier.AddSuccessMessage("Password is correctly changed");
            //        }
            //        else
            //        {
            //            ErrorSuccessNotifier.AddErrorMessage(string.Join(", ", isPassReset.Errors));
            //        }
            //    }
            //    else
            //    {
            //        ErrorSuccessNotifier.AddErrorMessage(string.Join(", ", result.Errors));
            //    }
            //}
        }
    }
}