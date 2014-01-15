using BirthdayPresentPlanner.Model;
using BirthdayPresentPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayPresentPlanner
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Questionnaire> Questionnaries { get; }
        IRepository<ApplicationUser> Users { get; }
        IRepository<Present> Presents { get; }
        IRepository<Vote> Votes { get; }
        int SaveChanges();
      
    }
}
