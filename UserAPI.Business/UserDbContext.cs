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
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = Guid.NewGuid(),
                    FirstName = "admin",
                    LastName = "admin",
                    CreatedDate = DateTime.Now,
                    CreatedUserId = Guid.Empty,
                    UpdatedDate = DateTime.Now,
                    UpdatedUserId = Guid.Empty,
                    IsDeletable = false,
                    IsDeleted = false,
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
