using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAPI.Domain;

namespace UserAPI.Business
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "admin",
                    LastName = "admin",
                    CreatedDate = DateTime.UtcNow,
                    CreatedUserId = Guid.Empty,
                    UpdatedDate = null,
                    UpdatedUserId = Guid.Empty,
                    IsDeletable = false,
                    IsDeleted = false,
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
