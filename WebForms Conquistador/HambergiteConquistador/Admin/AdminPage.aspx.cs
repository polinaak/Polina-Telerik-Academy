using Error_Handler_Control;
using HambergiteConquistador.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador.Admin
{
    public partial class AdminPage : System.Web.UI.Page
    {
        private const int TokenIDLenght = 128;
        private const int LastingOfAuth = 5;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private AspNetToken GenerateAdminToken(int expiersInMinutes)
        {

            return new AspNetToken() { Id = GenerateToken(), ValidUntilUtc = DateTime.Now.AddMinutes(expiersInMinutes) };
        }

        private  string GenerateToken()
        {
            //var buffer = new byte[16];

            //using (var crypto = new RNGCryptoServiceProvider())
            //{
            //    crypto.GetBytes(buffer);
            //}

            //return HttpServerUtility.UrlTokenEncode(buffer);

            var result = Convert.ToBase64String(new Guid().ToByteArray()).ToString();
            return result;
        }
               

        protected void EditQuestions_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditQuestions.aspx");
        }


        protected void CreateQuestions_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateQuestion.aspx");
        }

        protected void GetPermissions_Click(object sender, EventArgs e)
        {
            bool isAdmin = User.IsInRole("Admin");

            if (this.Page.User.Identity != null &&
               this.Page.User.Identity.IsAuthenticated &&
               isAdmin)
            {
                AspNetToken token = GenerateAdminToken(LastingOfAuth);

                ConquistadorEntities context = new ConquistadorEntities();
                context.AspNetTokens.Add(token);
                Session.Add("AdminTokenId", token.Id);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception ex)
                {

                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }


                ErrorSuccessNotifier.AddInfoMessage(string.Format("You have full permisions for this section in the next {0} minutes.", LastingOfAuth));

            }
            else
            {
                ErrorSuccessNotifier.AddWarningMessage("You don't have full permishions.");
            }
        }

       

        protected void ApproveQuestions_Click(object sender, EventArgs e)
        {
            Response.Redirect("ApproveQuestions.aspx");
        }
    }
}