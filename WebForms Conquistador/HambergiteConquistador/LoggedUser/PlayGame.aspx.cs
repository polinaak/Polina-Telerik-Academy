using HambergiteConquistador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HambergiteConquistador.LoggedUser
{
    public partial class PlayGame : System.Web.UI.Page
    {
        private const int QuestionScore = 10;
        private const int AnswerBonus = 2;
        private const int JokerBonus = 10;
        private Random rand = new Random();
        //int QuestionId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetQuestion();
            }
        }

        protected void GetQuestion()
        {
            using (ConquistadorEntities db = new ConquistadorEntities())
            {
                // var questions = db.Questions.Where(x => x.IsApproved == true);
                var questions = db.Questions.Include("Answers").OrderBy(x => Guid.NewGuid());
                var x1 = questions.ToList().Count;
                var question = questions.First(x => x.IsApproved == true);

                this.MakePictureFromText.QuestionText = question.TextContent;
                //
                this.LiteralQuestion.Text = question.TextContent;
                string userName = this.Page.User.Identity.Name;
                var currentUser = db.AspNetUsers.FirstOrDefault(u => u.UserName == userName);
                this.LiteralBonus.Text = currentUser.Bonus.ToString();
                this.LiteralScore.Text = currentUser.Score.ToString();

                IEnumerable<Answer> answers = question.Answers.OrderBy(a => Guid.NewGuid());
                var randomisedAnsvers = answers.Take(4).ToList();

                if (randomisedAnsvers.FirstOrDefault(a => a.IsCorrect == true) == null)
                {
                    var correctAnswer = answers.FirstOrDefault(a => a.IsCorrect == true);
                    int index = rand.Next(0,4);
                    randomisedAnsvers[index] = correctAnswer;
                }
                //this.LiteralTemp.Text = "==" + string.Join(": ", randomisedAnsvers) + "==";
                this.RadioButtonListAnswers.DataSource = randomisedAnsvers;
                this.RadioButtonListAnswers.DataBind();
                this.ButtonNextQuestion.Visible = false;
                this.LiteralAnswer.Text = string.Empty;
            }
        }
        //public IQueryable <Answer> RadioButtonListAnswers_GetData( int questionId)
        //{
        //    ConquistadorEntities db = new ConquistadorEntities();
        //    IQueryable<Answer> answers = db.Answers.Where(a => a.QuestionId == questionId);
        //    IQueryable<Answer> randomisedAnsvers = answers.OrderBy(a => Guid.NewGuid()).Take(4);
        //    bool containsRightAnswer = randomisedAnsvers.FirstOrDefault(a => a.IsCorrect == true) == null;

        //    while (containsRightAnswer)
        //    {
        //        randomisedAnsvers = answers.OrderBy(a => Guid.NewGuid()).Take(4);
        //        containsRightAnswer = randomisedAnsvers.FirstOrDefault(a => a.IsCorrect == true) == null;
        //    }

        //    return randomisedAnsvers;
        //}

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (this.RadioButtonListAnswers.SelectedValue != null 
                && !string.IsNullOrWhiteSpace(this.RadioButtonListAnswers.SelectedValue))
            {
                int answerId = Convert.ToInt32(this.RadioButtonListAnswers.SelectedValue);
                using (ConquistadorEntities db = new ConquistadorEntities())
                {
                    Answer answer = db.Answers.FirstOrDefault(a => a.Id == answerId);

                    if (answer.IsCorrect == true)
                    {
                        // answer correct
                        //this.LiteralAnswer.Text = "Aswer Correct!";
                        Error_Handler_Control.ErrorSuccessNotifier.AddSuccessMessage("Aswer Correct!");
                        string userName = this.Page.User.Identity.Name;
                        var currentUser = db.AspNetUsers.FirstOrDefault(u => u.UserName == userName);
                        currentUser.Score += QuestionScore;
                        currentUser.Bonus += AnswerBonus;
                        db.SaveChanges();
                        this.LiteralBonus.Text = currentUser.Bonus.ToString();
                        this.LiteralScore.Text = currentUser.Score.ToString();
                    }
                    else
                    {
                        //// answer incorrect
                        Error_Handler_Control.ErrorSuccessNotifier.AddErrorMessage("Aswer Incorrect!");
                        for (int i = 0; i < 4; i++)
                        {
                            int ansId = Convert.ToInt32(this.RadioButtonListAnswers.Items[i].Value);
                            Answer currAnswer = db.Answers.FirstOrDefault(a => a.Id == ansId);
                            if (currAnswer.IsCorrect == true)
                            {
                                this.LiteralAnswer.Text = "Correct answer is: " + this.RadioButtonListAnswers.Items[i].Text;
                                break;
                            }
                        }
                    }
                }

                this.RadioButtonListAnswers.Visible = false;
                this.ButtonSubmit.Visible = false;
                this.ButtonNextQuestion.Visible = true;
                this.ButtonJoker25.Visible = false;
                this.ButtonJoker50.Visible = false;
            }
        }

        protected void ButtonNextQuestion_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/LoggedUser/PlayGame.aspx");
            GetQuestion();
            this.RadioButtonListAnswers.Visible = true;
            this.ButtonSubmit.Visible = true;
            this.ButtonNextQuestion.Visible = false;
            this.ButtonJoker25.Visible = true;
            this.ButtonJoker50.Visible = true;
        }

        protected void ButtonJoker25_Click(object sender, EventArgs e)
        {
            string userName = this.Page.User.Identity.Name; 
            ConquistadorEntities db = new ConquistadorEntities();
            var currentUser = db.AspNetUsers.FirstOrDefault(u => u.UserName == userName);
            db.AspNetUsers.Attach(currentUser);
            if (currentUser.Bonus >= JokerBonus)
            {
                currentUser.Bonus -= JokerBonus;
                while (true)
                {
                    int random = rand.Next(0, 4);
                    int answerId = Convert.ToInt32(this.RadioButtonListAnswers.Items[random].Value);
                    Answer answer = db.Answers.FirstOrDefault(a => a.Id == answerId);
                    if (answer.IsCorrect != true)
                    {
                        RadioButtonListAnswers.Items[random].Text = "";
                        this.ButtonJoker25.Visible = false;
                        this.ButtonJoker50.Visible = false;
                        break;
                    }
                }
                this.LiteralBonus.Text = currentUser.Bonus.ToString();
                db.SaveChanges();
            }
            else
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddInfoMessage("No enought bonus points!");
            }
        }

        protected void ButtonJoker50_Click(object sender, EventArgs e)
        {
            string userName = this.Page.User.Identity.Name;
            ConquistadorEntities db = new ConquistadorEntities();
            var currentUser = db.AspNetUsers.FirstOrDefault(u => u.UserName == userName);
            db.AspNetUsers.Attach(currentUser);
            if (currentUser.Bonus >= JokerBonus*2)
            {
                currentUser.Bonus -= JokerBonus*2;
                int count = 0;
                while (true)
                {
                    int random = rand.Next(0, 4);
                    int answerId = Convert.ToInt32(this.RadioButtonListAnswers.Items[random].Value);
                    Answer answer = db.Answers.FirstOrDefault(a => a.Id == answerId);
                    if (answer.IsCorrect != true && RadioButtonListAnswers.Items[random].Text != "")
                    {
                        RadioButtonListAnswers.Items[random].Text = "";
                        this.ButtonJoker25.Visible = false;
                        this.ButtonJoker50.Visible = false;
                        count++;
                        if (count >=2 )
                        {
                            break;
                        }
                    }
                }

                this.LiteralBonus.Text = currentUser.Bonus.ToString();
                db.SaveChanges();
            }
            else
            {
                Error_Handler_Control.ErrorSuccessNotifier.AddInfoMessage("No enough bonus points!");
            }
        }
    }
}