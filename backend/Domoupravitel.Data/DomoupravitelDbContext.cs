﻿using Domoupravitel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domoupravitel.Data
{
    public class DomoupravitelDbContext : DbContext, IDomoupravitelDbContext
    {
        public DomoupravitelDbContext(DbContextOptions options) : base(options)
        {
            this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(p => p.Id).ValueGeneratedOnAdd();
                entity.Property(p => p.Name).IsRequired();
                entity.Property(p => p.UserName).IsRequired();
                entity.Property(p => p.PasswordHash).IsRequired();
                entity.HasData(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "wnvko",
                    UserName = "wnvko",
                    PasswordHash = hasher.HashPassword(null, "par01a"),
                });
            });
        }

        public DbSet<User> Users { get; set; }

        public new DbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
