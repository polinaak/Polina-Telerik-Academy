using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Models;

namespace Twitter.Data
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
            var adminRole = context.Roles.FirstOrDefault(r => r.Name == "Admin");

            if (adminRole == null)
            {
                string[] tags = new string[] {
                    "cute", "umbrella", "sun", "rain", "tea", "kitty", "sport", "smile", "nice",
                    "beauty", "cloudy", "autumn", "winter", "Dan Brown", "Angels and Demons", "C#", "JavaScript", "Lie to me",
                    "Chase and Status", "new", "strange", "happy", "cozy", "hugs", "kisses", "smurfs", "fresh"
                };

                string[] tweetsMessages = new string[] {
                    "cute", "umbrella", "sun", "rain", "tea", "kitty", "sport", "smile", "nice",
                    "beauty", "cloudy", "autumn", "winter", "Dan Brown", "Angels and Demons", "C#", "JavaScript", "Lie to me",
                    "Chase and Status", "new", "strange", "happy", "cozy", "hugs", "kisses", "smurfs", "fresh"
                };


                foreach (var tag in tags)
                {
                    Tag newTag = new Tag
                    {
                        Name = tag
                    };
                    
                    context.Tags.Add(newTag);
                }

                foreach (var message in tweetsMessages)
                {
                    Tweet tweet = new Tweet
                    {
                        Message = message,
                        DateCreated = DateTime.Now
                    };

                    context.Tweets.Add(tweet);
                }


                Role admin = new Role
                {
                    Name = "Admin"
                };

                context.Roles.Add(admin);

                context.SaveChanges();
            }

            base.Seed(context);
        }
    }
}

