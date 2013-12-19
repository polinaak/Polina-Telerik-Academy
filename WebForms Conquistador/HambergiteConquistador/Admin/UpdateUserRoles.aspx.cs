using Error_Handler_Control;
using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador.Admin
{
    public partial class UpdateUserRoles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        public IQueryable<AspNetRole> DDLRoles_GetData()
        {
            ConquistadorEntities context = new ConquistadorEntities();

            return context.AspNetRoles;
        }

        protected void AddRole_Click(object sender, EventArgs e)
        {
            ConquistadorEntities context = new ConquistadorEntities();

            var roleId = this.DDLRoles.SelectedValue;

            var role  = context.AspNetRoles.FirstOrDefault(r => r.Id == roleId);

            if (role == null)
	        {
		        ErrorSuccessNotifier.AddErrorMessage("Invalid role.");
                return;
	        }

            var userName = this.Request.Params["userName"];

            var user = context.AspNetUsers.Include("AspNetRoles").FirstOrDefault( u => u.UserName ==  userName);

            if (user == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Can not find user.");
                return;
            }

            var roles = user.AspNetRoles;

            if (roles != null)
            {
                
            }

            var conatinRole = user.AspNetRoles.FirstOrDefault(r => r.Id == roleId);

            if (conatinRole != null)
            {
                ErrorSuccessNotifier.AddErrorMessage("User is already in this role.");
                return;
            }


            user.AspNetRoles.Add(role);

            try
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Role succssesfuly added.");
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
            
        }

    
        public IQueryable<AspNetRole> ListViewUserRole_GetData()
        {
            ConquistadorEntities context = new ConquistadorEntities();
            var userName = this.Request.Params["userName"];
            var user = context.AspNetUsers.Include("AspNetRoles").FirstOrDefault( u => u.UserName ==  userName);
         
            return user.AspNetRoles.OrderBy( r => r.Name).AsQueryable();
        
        }

        // not in use
        public void ListViewUserRole_UpdateItem(string id)
        {
            ConquistadorEntities context = new ConquistadorEntities();
            var userName = this.Request.Params["userName"];
            var user = context.AspNetUsers.Include("AspNetRoles").FirstOrDefault(u => u.UserName == userName);
            var role = user.AspNetRoles.FirstOrDefault(r => r.Id == id);
            user.AspNetRoles.Remove(role);

            var roleNew = context.AspNetRoles.FirstOrDefault(r => r.Name == role.Name && r.Id != role.Id);

            roleNew.AspNetUsers.Add(user);

            
            try
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("ToDoList is edited");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
  
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void ListViewUserRole_DeleteItem(string id)
        {
            ConquistadorEntities context = new ConquistadorEntities();
            var userName = this.Request.Params["userName"];
            var user = context.AspNetUsers.Include("AspNetRoles").FirstOrDefault(u => u.UserName == userName);

            var role = user.AspNetRoles.FirstOrDefault( r=> r.Id == id);

            user.AspNetRoles.Remove(role);

            try
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Role succssesfuly removed.");
            }
            catch (Exception ex)
            {

                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}