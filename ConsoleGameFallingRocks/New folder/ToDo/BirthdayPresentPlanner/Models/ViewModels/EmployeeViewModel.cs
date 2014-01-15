using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BirthdayPresentPlanner.Models
{
    public class EmployeeViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }
        public DateTime BirthDate { get; set; }
        public static Expression<Func<ApplicationUser, EmployeeViewModel>> FromApplicationUser
        {
            get
            {
                return employee => new EmployeeViewModel
                {
                    Id = employee.Id,
                    UserName = employee.UserName,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    BirthDate = employee.BirthDate,

                };
            }
        }        
    }
}