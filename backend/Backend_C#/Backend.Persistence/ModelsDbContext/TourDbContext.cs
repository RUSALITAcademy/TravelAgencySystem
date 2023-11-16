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
    public class TourDbContext
        : DbContext, ITourDbContext
    {
        public DbSet<Tour> Tour { get; set; }

        public TourDbContext(DbContextOptions<TourDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TourConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
