using LaptopSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopSystem.Data
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
            if (context.Laptops.Count() > 0)
            {
                return;
            }
            else
            {
                Manufacturer testManufacturer = new Manufacturer
                {
                    Name = "Acer"
                };

                context.Manufacturers.Add(testManufacturer);

                ApplicationUser testUser = new ApplicationUser
                {
                    UserName = "TestUser",
                    Email = "test@test.com",
                };

                Random rand = new Random();

                for (int i = 0; i < 14; i++)
                {
                    Laptop laptop = new Laptop();
                    laptop.Model = "Aspire";
                    laptop.HardDisk = rand.Next(150, 1000);
                    laptop.Price = rand.Next(400, 3000);
                    laptop.RAM = rand.Next(2, 16);
                    laptop.Monitor = 15.5;
                    laptop.ImageUrl = "http://laptop.bg/system/images/25129/thumb/acer_aspire_v5572g_NX_MAKEX_008.jpg?1375964403";
                    laptop.Weight = 1.5;
                    laptop.AdditionalParts = "Bluethoot";
                    laptop.Description = "Mate Display";
                    laptop.Manufacturer = testManufacturer;

                    var votesCount = new Random();
                    for (int j = 0; j  < votesCount.Next(1, 10); j ++)
                    {
                        laptop.Votes.Add(new Vote { Laptop = laptop, User = testUser, VotedBy = testUser.UserName });
                    }

                    var commentsCount = new Random();
                    for (int j = 0; j < commentsCount.Next(1, 10); j++)
                    {
                        laptop.Comments.Add(new Comment { Laptop = laptop, Content = "Cool laptop", User = testUser });
                    }
                    context.Laptops.Add(laptop);
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
