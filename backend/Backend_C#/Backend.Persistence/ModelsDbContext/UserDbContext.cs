using Backend.Application.Interfaces;
using Backend.Domain.Models;
using Backend.Persistence.EntityTypeConfigurations;
using Microsoft.AspNetCore.Identity;
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
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "62d969be-785d-4219-b286-9b65a8718a99", Name = "User", NormalizedName = "User" },
                new IdentityRole { Id = "0d2a7796-5724-482c-a280-5cc853619c38", Name = "Admin", NormalizedName = "Admin" },
                new IdentityRole { Id = "6c451fc5-7063-4c3b-a52b-528e930e1885", Name = "TourAgency", NormalizedName = "TourAgency" }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
