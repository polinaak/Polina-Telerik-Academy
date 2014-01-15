using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PresentsApp.Models.ViewModels
{
    public class QuestViewModel
    {
        public int QuestId { get; set; }

        public int EmployeeId { get; set; }

        public int Year { get; set; }

        public static Expression<Func<Quest, QuestViewModel>> FromQuest
        {
            get
            {
                return quest => new QuestViewModel
                {
                    QuestId = quest.QuestId,
                    EmployeeId = quest.EmployeeId,
                    Year = quest.Year
                };
            }
        }
    }
}