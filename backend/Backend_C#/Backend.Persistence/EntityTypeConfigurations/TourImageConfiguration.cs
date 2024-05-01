using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Persistence.EntityTypeConfigurations
{
    public class TourImageConfiguration : IEntityTypeConfiguration<TourImage>
    {
        public void Configure(EntityTypeBuilder<TourImage> entity)
        {
            entity.HasIndex(tourImage => tourImage.Id).IsUnique();

            entity.HasOne(tourImage => tourImage.Tour)
                .WithMany(tour => tour.Images)
                .HasForeignKey(tourImage => tourImage.TourId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
