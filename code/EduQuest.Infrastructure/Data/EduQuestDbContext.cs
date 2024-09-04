using EduQuest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EduQuest.Infrastructure.Data
{
    public class EduQuestDbContext : DbContext
    {
        public EduQuestDbContext(DbContextOptions<EduQuestDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Hyperlink> Hyperlinks { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Domain.Entities.DomainInfo> Domains { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(a => a.UserId);

                entity.Property(a => a.UserName)
                      .IsRequired();

                entity.Property(a => a.Email)
                      .IsRequired();

                entity.Property(a => a.Contact)
                      .IsRequired();

                entity.Property(a => a.IsActive);
            });

            // Configure the Role entity
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(a => a.RoleId);

                entity.Property(a => a.RoleName)
                      .IsRequired();
            });

        }








    }
}
