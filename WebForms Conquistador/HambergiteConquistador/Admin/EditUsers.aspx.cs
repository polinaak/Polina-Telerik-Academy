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
    public partial class EditUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<AspNetUser> GridViewEditUsers_GetData()
        {
            ConquistadorEntities context = new ConquistadorEntities();

            return context.AspNetUsers;
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewEditUsers_UpdateItem(string id)
        {
            ConquistadorEntities context = new ConquistadorEntities();
            var product = context.AspNetUsers.Find(id);
            TryUpdateModel(product);
            if (ModelState.IsValid)
            {
                try
                {
                    context.SaveChanges();
                    ErrorSuccessNotifier.AddInfoMessage("User is edited");
                }
                catch (Exception ex)
                {
                    ErrorSuccessNotifier.AddErrorMessage(ex);
                }

            }      
        }

        // The id parameter name should match the DataKeyNames value set on the control
        public void GridViewEditUsers_DeleteItem(string id)
        {
            ConquistadorEntities context = new ConquistadorEntities();
            var user = context.AspNetUsers.Find(id);
            context.AspNetUsers.Remove(user);

            try
            {
                context.SaveChanges();
                ErrorSuccessNotifier.AddInfoMessage("User is deleted");
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex);
            }
        }
    }
}