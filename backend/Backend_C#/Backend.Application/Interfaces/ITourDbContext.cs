using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Interfaces
{
    public interface ITourDbContext
    {
        DbSet<Tour> Tour { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
