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
            //! написать будущую конфигурацию связей между таблицами в бд!
        }

    }
}
