using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PresentsApp.Models.Data
{
    public class DataContext : PresentsAppEntities
    {
        public DbSet<Present> Presents { get; set; }
        public DbSet<Quest> Quests { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Vote> Votes { get; set; }
    }
}