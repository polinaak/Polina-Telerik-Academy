using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HambergiteConquistador.Models;
using Error_Handler_Control;

namespace HambergiteConquistador.LoggedUser
{
    public partial class SuggestQuestion : System.Web.UI.Page
    {
        private const int NumberOfAnswers = 4;
       
        protected void Page_PreRender(object sender, EventArgs e)
        {
            TextBoxAnswer1.Text = "";
            TextBoxAnswer2.Text = "";
            TextBoxAnswer3.Text = "";
            TextBoxAnswer4.Text = "";
            TextBoxQuestion.Text = "";
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string questionText = this.TextBoxQuestion.Text;
            //validate q
            if (string.IsNullOrEmpty(questionText))
            {
                ErrorSuccessNotifier.AddErrorMessage("The question field cannot be empty!");
                return;
            }

            List<Answer> answers = new List<Answer>();
            answers.Add(new Answer() { ContentText = this.TextBoxAnswer1.Text });
            answers.Add(new Answer() { ContentText = this.TextBoxAnswer2.Text });
            answers.Add(new Answer() { ContentText = this.TextBoxAnswer3.Text });
            answers.Add(new Answer() { ContentText = this.TextBoxAnswer4.Text });            
            //validate answers

            int correctAnswerIndex = int.Parse(this.DropDownCorrectAnswer.SelectedValue) - 1;
            for (int i = 0; i < answers.Count; i++)
            {
                if (string.IsNullOrEmpty(answers[i].ContentText))
                {
                    ErrorSuccessNotifier.AddErrorMessage("An answer field cannot be empty.");
                    return;
                }
                if (i == correctAnswerIndex)
                {
                    answers[i].IsCorrect = true;
                    break;
                }
            }
            try
            {
                ConquistadorEntities context = new ConquistadorEntities();
                Question created = new Question() { TextContent = questionText, Answers = answers, IsApproved = false };
                context.Questions.Add(created);
                context.SaveChanges();
                ErrorSuccessNotifier.AddSuccessMessage("Question was added.");
                
            }
            catch (Exception ex)
            {
                ErrorSuccessNotifier.AddErrorMessage(ex.Message);
            }
        }
    }
}