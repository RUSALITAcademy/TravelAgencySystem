using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.EntityTypeConfigurations
{
    public class TourConfiguration
        : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> entity)
        {
            entity.HasIndex(tour => tour.TourId).IsUnique();
           

            entity.HasMany(tour => tour.Orders)
              .WithOne(order => order.Tour)
              .HasForeignKey(order => order.TourId);
        }

    }

}
