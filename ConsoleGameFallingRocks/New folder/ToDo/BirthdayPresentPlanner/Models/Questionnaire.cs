//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BirthdayPresentPlanner.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Questionnaire
    {
        public Questionnaire()
        {
            this.Votes = new HashSet<Vote>();
        }
    
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int Year { get; set; }
    
        public virtual AspNetUser Employee { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
