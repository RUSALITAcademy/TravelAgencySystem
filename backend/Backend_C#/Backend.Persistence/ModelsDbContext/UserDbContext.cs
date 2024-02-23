using Backend.Application.Interfaces;
using Backend.Domain.Models;
using Backend.Persistence.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.ModelsDbContext
{
    public class UserDbContext 
        : IdentityDbContext<User>, IUserDbContext
    {
        public DbSet<User> User { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) 
            : base (options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}
