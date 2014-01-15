using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace PresentsApp.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public static Expression<Func<UserProfile, EmployeeViewModel>> FromUserProfile
        {
            get
            {
                return user => new EmployeeViewModel
                {
                    EmployeeId = user.UserId,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
            }
        }
    }
}