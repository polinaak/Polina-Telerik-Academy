using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.User.Identity != null && this.Page.User.Identity.IsAuthenticated)
            {
                string userName = this.Page.User.Identity.Name;

                this.greeting.InnerText = string.Format("Hello, {0}! We are glad to see you again!", userName);
            }
        }
    }
}