using System;
using System.Data.Entity;
using System.Linq;
using Places.Models;

namespace Places.Data
{
    public class PlacesContext : DbContext
    {
        public PlacesContext()
            : base("PlacesDb")
        { 
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(user => user.SessionKey)
                .IsFixedLength()
                .HasMaxLength(50);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(user => user.AuthCode)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(40);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(user => user.Nickname)
                .IsRequired()
                .HasMaxLength(30);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(user => user.Username)
                .IsRequired()
                .HasMaxLength(30);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Place>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Town>()
               .Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(50);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Country>()
               .Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(40);
            base.OnModelCreating(modelBuilder);
        }
    }
}
