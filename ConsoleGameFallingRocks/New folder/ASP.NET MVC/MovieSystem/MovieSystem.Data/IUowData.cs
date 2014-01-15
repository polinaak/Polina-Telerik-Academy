using Microsoft.AspNet.Identity.EntityFramework;
using MovieSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Data
{
    public interface IUowData : IDisposable
    {
        IRepository<Movie> Movies { get; }

        IRepository<Studio> Studios { get; }

        IRepository<LeadingRoles> LeadingRoles { get; }

        int SaveChanges();
    }
}
