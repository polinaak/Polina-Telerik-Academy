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
    public partial class EditAnswers1 : System.Web.UI.Page
    {
        private bool isNewAnswer = false;
        private Answer answer;
        private Question question;
        private int questionId;
        private int answerId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.questionId =
                Convert.ToInt32(Request.Params["questionId"]);
            this.answerId =
                Convert.ToInt32(Request.Params["answerId"]);
            isNewAnswer = (this.answerId == 0);
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new ConquistadorEntities();

            if (answerId == 0)
            {
                isNewAnswer = true;
            }

            if (!isNewAnswer)
            {
                answer = context.Answers.Find(answerId);
                this.TextBoxEdit.Text = answer.ContentText;
                this.DataBind();
            }

            else
            {
                this.TextBoxEdit.Text = "";
            }

        }


        protected void EditAnswer_Command(object sender, CommandEventArgs e)
        {
            var context = new ConquistadorEntities();

            question = context.Questions.Find(questionId);

            if (answerId == 0)
            {
                isNewAnswer = true;
                answer = new Answer();
                answer.QuestionId = question.Id;
                context.Answers.Add(answer);
            }

            if (!isNewAnswer)
            {
                answer = context.Answers.Find(answerId);
            }

            try
            {
                answer.ContentText = this.TextBoxEdit.Text;
                context.SaveChanges();
                Response.Redirect("EditQuestions.aspx", false);
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
                return;
            }

        }
    }
}