using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Persistence.EntityTypeConfigurations
{
    public class UserConfiguration 
        :  IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasIndex(user => user.UserId).IsUnique();

            entity.HasMany(user => user.Orders)
             .WithOne(order => order.User)
             .HasForeignKey(order => order.UserId);

            entity.HasOne(user => user.Passport)
              .WithOne(passport => passport.User)
              .HasForeignKey<Passport>(passport => passport.UserId);

            // Связь с InternationalPassport (один к одному)
            entity.HasOne(user => user.InternationalPassport)
                  .WithOne(passport => passport.User)
                  .HasForeignKey<InternationalPassport>(passport => passport.UserId);

        }
    }
}
