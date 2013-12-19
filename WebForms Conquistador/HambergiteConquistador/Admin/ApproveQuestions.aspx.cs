using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Error_Handler_Control;

namespace HambergiteConquistador.Admin
{
    public partial class ApproveQuestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new ConquistadorEntities();
            using (context)
            {
                var pendingQuestions = context.Questions.Where(q => q.IsApproved != true);
                this.ListViewAllQuestions.DataSource = pendingQuestions.ToList();
                this.DataBind();
            }
        }

        protected void Edit_Command(object sender, CommandEventArgs e)
        {
            var context = new ConquistadorEntities();
            var questionId = Convert.ToInt32(e.CommandArgument);
            Question question = context.Questions.Find(questionId);
            Response.Redirect("EditQuestion.aspx?id=" + question.Id);
        }

        protected void Delete_Command(object sender, CommandEventArgs e)
        {
            var context = new ConquistadorEntities();

            try
            {
                int answerId = Convert.ToInt32(e.CommandArgument);
                var answer = context.Answers.Find(answerId);
                context.Answers.Remove(answer);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }
    }
}