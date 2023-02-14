using Microsoft.EntityFrameworkCore;
using Domoupravitel.Models;
using Microsoft.AspNetCore.Identity;

namespace Domoupravitel.Data
{
    public class DomoupravitelDbContext : DbContext, IDomoupravitelDbContext
    {
        public DomoupravitelDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<IdentityUser>(entity =>
            //{
            //    entity.HasKey(e => e.Id);
            //    entity.Property(p => p.Id).ValueGeneratedOnAdd();
            //    entity.Property(p => p.Name).IsRequired();
            //    entity.Property(p => p.Password).IsRequired();
            //    entity.HasData(new User { Id = 1, Name = "wnvko", Password = "par01a" });
            //});
        }

        public DbSet<IdentityUser> Users { get; set; }

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
