using Microsoft.EntityFrameworkCore;
using Backend.Domain.Models;

namespace Backend.Application.Interfaces
{
    public interface IUserDbContext
    {
        DbSet<User> User { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
