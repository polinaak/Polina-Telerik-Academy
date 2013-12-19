using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador
{
    public partial class Scores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonPlayOrRegister_Click(object sender, EventArgs e)
        {

            if (this.Page.User.Identity != null && this.Page.User.Identity.IsAuthenticated)
            {
                Response.Redirect("~/LoggedUser/PlayGame.aspx");
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }

        public IQueryable<AspNetUser> GridViewScores_GetData()
        {
            ConquistadorEntities db = new ConquistadorEntities();
            var users = db.AspNetUsers.OrderByDescending(x=>x.Score);
            return users;
        }
    }
}