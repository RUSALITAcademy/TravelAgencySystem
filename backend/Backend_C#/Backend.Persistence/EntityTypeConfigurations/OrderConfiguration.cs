using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Backend.Persistence.EntityTypeConfigurations
{
    public class OrderConfiguration
        : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.HasIndex(order => order.OrderId).IsUnique();


            entity.HasOne(order => order.User)
              .WithMany(user => user.Orders)
              .HasForeignKey(order => order.UserId);

            entity.HasOne(order => order.Tour)
                  .WithMany(tour => tour.Orders)
                  .HasForeignKey(order => order.TourId);
        }

    }
}
