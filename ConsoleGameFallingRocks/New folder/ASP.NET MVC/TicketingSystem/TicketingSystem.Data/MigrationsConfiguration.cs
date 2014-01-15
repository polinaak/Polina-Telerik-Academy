using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketingSystem.Models;

namespace TicketingSystem.Data
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
            if (context.Tickets.Count() > 0)
            {
                return;
            }
            else
            {
                Category testCategory = new Category
                {
                    Name = "Software Development"
                };

                ApplicationUser testUser = new ApplicationUser
                {
                    UserName = "TestUser"
                };

                Random rand = new Random();

                for (int i = 0; i < 14; i++)
                {
                    Ticket ticket = new Ticket();
                    ticket.Category = testCategory;
                    ticket.Description = "Nothing works!";
                    ticket.Priority = Priority.Medium;
                    ticket.ScreenshotUrl = "http://www.ericfoster.org/wp-content/uploads/2011/05/bug_vs_feature.gif";
                    ticket.Title = "Help me!";
                    ticket.Author = testUser;
                    
                    var commentsCount = new Random();
                    for (int j = 0; j < commentsCount.Next(1, 10); j++)
                    {
                        ticket.Comments.Add(new Comment {Content = "Wow, I dont know", Author = testUser });
                    }
                    context.Tickets.Add(ticket);
                }
                context.SaveChanges();
            }

            base.Seed(context);
        }

    }
}
