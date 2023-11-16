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
    public class InternationalPassportConfiguration : IEntityTypeConfiguration<InternationalPassport>
    {
        public void Configure(EntityTypeBuilder<InternationalPassport> entity)
        {
            entity.HasKey(passport => passport.InternationalPassportId);

            // Связь с пользователем (один к одному)
            entity.HasOne(passport => passport.User)
                  .WithOne(user => user.InternationalPassport)
                  .HasForeignKey<InternationalPassport>(passport => passport.UserId);
        }

    }
}
