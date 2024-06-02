using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.EntityTypeConfigurations
{
    public class TourConfiguration : IEntityTypeConfiguration<Tour>
    {
        public void Configure(EntityTypeBuilder<Tour> entity)
        {
            entity.HasKey(t => t.TourId);
            entity.HasIndex(t => t.TourId).IsUnique();

            entity.HasMany(t => t.Images)
                .WithOne(i => i.Tour)
                .HasForeignKey(i => i.TourId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(t => t.Orders)
                .WithOne(order => order.Tour)
                .HasForeignKey(order => order.TourId);

        }
    }


}
