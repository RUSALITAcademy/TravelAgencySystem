using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Persistence.EntityTypeConfigurations
{
    public class PassportConfiguration : IEntityTypeConfiguration<Passport>
    {
        public void Configure(EntityTypeBuilder<Passport> entity)
        {
            entity.HasKey(passport => passport.PassportId);

            entity.HasOne(passport => passport.User)
              .WithOne(user => user.Passport)
              .HasForeignKey<Passport>(passport => passport.UserId);
        }

    }
}
