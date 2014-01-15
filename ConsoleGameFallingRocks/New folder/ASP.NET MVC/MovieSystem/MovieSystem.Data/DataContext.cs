using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MovieSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MovieSystem.Data
{
    public class DataContext : IdentityDbContextWithCustomUser<User>
    {
        public IDbSet<Movie> Movies {get; set;}

        public IDbSet<Studio> Studios { get; set; }

        public IDbSet<LeadingRoles> LeadingRoles { get; set; }
    }
}
