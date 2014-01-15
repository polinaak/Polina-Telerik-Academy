using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BirthdayPresentPlanner.Models.ViewModels
{
    public class QuestionnaireViewModel
    {
        public int Id { get; set; }       
        public string EmployeeId { get; set; }
        public int Year { get; set; }

        public static Expression<Func<Questionnaire, QuestionnaireViewModel>> FromQuestionnaire
        {
            get
            {
                return quest => new QuestionnaireViewModel
                {
                    Id = quest.Id,
                    EmployeeId = quest.EmployeeId,
                    Year = quest.Year
                };
            }
        }        
    }
}