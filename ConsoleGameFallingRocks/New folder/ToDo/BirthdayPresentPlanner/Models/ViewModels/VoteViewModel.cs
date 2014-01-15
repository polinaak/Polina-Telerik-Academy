using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BirthdayPresentPlanner.Models.ViewModels
{
    public class VoteViewModel
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Present { get; set; }

        public int QuestId { get; set; }

        public static Expression<Func<Vote, VoteViewModel>> FromVote
        {
            get
            {
                return vote => new VoteViewModel
                {
                    Id = vote.Id,
                    EmployeeId = vote.EmployeeId,
                    QuestId = vote.QuestionnaireId,
                    Present = vote.Present.Name
                };
            }
        }        
    }
}