using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using BirthdayPresentPlanner.Model;
using BirthdayPresentPlanner.Models;

namespace BirthdayPresentPlanner
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public IDbSet<Questionnaire> Questionnaires { get; set; }
        public IDbSet<Present> Presents { get; set; }
        public IDbSet<Vote> Votes { get; set; }

    }   
}
