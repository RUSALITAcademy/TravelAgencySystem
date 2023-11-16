using Backend.Application.Interfaces;
using Backend.Domain.Models;
using Backend.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Persistence.ModelsDbContext
{
    public class PassportDbContext : DbContext, IPassportDbContext
    {
        public DbSet<Passport> Passport { get; set; }

        public PassportDbContext(DbContextOptions<PassportDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PassportConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
