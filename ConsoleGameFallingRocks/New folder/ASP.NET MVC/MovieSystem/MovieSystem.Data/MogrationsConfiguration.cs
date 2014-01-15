using MovieSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Data
{
    public class MigrationsConfiguration : DbMigrationsConfiguration<DataContext>
    {
        public MigrationsConfiguration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DataContext context)
        {
            if (!(context.Movies.Count() > 0))
            {
                string[] movies = new string[] {
                   "Zenon: The Zequel",
                    "Motocrossed",
                    "The Luck of the Irish",
                    "Hounded",
                    "Jett Jackson: The Movie", 
                    "The Jennie Project",
                    "Jumping Ship",
                    "The Poof Point",
                    "Halloweentown II: Kalabar's Revenge'Twas the Night "
                };

                Studio newStudio = new Studio
                {
                    StudioId = 1,
                    StudioAddress = "20th Century Fox",
                };
                context.Studios.Add(newStudio);
                Studio newStudio2 = new Studio
                    {
                        StudioId = 2,
                        StudioAddress = "BCC Films",
                    };
                context.Studios.Add(newStudio2);


                LeadingRoles leadingRoles = new LeadingRoles
                {
                    FemaleRole = "Jordana Brewster",
                    FemaleRoleAge = 34,
                    MaleRole = "Cam Gigandet",
                    MaleRoleAge = 27,
                    LeadingRolesId = 1
                };

                context.LeadingRoles.Add(leadingRoles);

                foreach (var movie in movies)
                {
                    Movie newMovie = new Movie
                    {
                        Title = movie,
                        Year = 1999,
                        Studio = newStudio,
                        Director = "J.J. Abrams",
                    };

                    context.Movies.Add(newMovie);
                }

                context.SaveChanges();


                base.Seed(context);
            }
        }
    }
}
