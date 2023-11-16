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
    public class InternationalPassportDbContext : DbContext, IInternationalPassportDbContext
    {
        public DbSet<InternationalPassport> InternationalPassport { get; set; }

        public InternationalPassportDbContext(DbContextOptions<InternationalPassportDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new InternationalPassportConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
