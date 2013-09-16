using System;
using System.Data.Entity;
using System.Linq;
using BloggingSystem.Models;

namespace BloggingSystem.Data
{
    public class BloggingSystemContext : DbContext
    {
        public BloggingSystemContext()
            : base("BloggingSystemDb")
        { }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(user => user.SessionKey)
                .IsFixedLength()
                .HasMaxLength(50);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(user => user.AuthCode)
                .IsFixedLength()
                .HasMaxLength(40);
            base.OnModelCreating(modelBuilder);
        }
    }
}
