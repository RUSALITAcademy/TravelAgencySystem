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
            entity.HasMany(user => user.Orders)
             .WithOne(order => order.User)
             .HasForeignKey(order => order.UserId);

        }
    }
}
