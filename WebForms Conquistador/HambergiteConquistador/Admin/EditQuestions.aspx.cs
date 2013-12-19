using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador.Admin
{
    public partial class EditAnswers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new ConquistadorEntities();
            using (context)
            {
                this.ListViewAllQuestions.DataSource = context.Questions.ToList();
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
            var questionId = Convert.ToInt32(e.CommandArgument);
            Question question = context.Questions.Include("Answers").FirstOrDefault(x => questionId == x.Id);

            context.Answers.RemoveRange(question.Answers);

            context.Questions.Remove(question);
            context.SaveChanges();
        }

        protected void ListViewAllQuestions_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
    }
}