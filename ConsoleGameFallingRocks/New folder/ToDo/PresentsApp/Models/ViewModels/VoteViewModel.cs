using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PresentsApp.Models.ViewModels
{
    public class VoteViewModel
    {
        public int VoteId { get; set; }

        public int PresentId { get; set; }

        public int EmployeeId { get; set; }

        public int QuestId { get; set; }

        public ICollection<string> Presents { get; set; }

        public static Expression<Func<Vote, VoteViewModel>> FromVote
        {
            get
            {
                return vote => new VoteViewModel 
                {
                    VoteId = vote.VoteId,
                    QuestId = vote.QuestId,
                    EmployeeId = vote.UserProfile.UserId,
                    PresentId = vote.PresentId,
                };
            }
        }
    }
}