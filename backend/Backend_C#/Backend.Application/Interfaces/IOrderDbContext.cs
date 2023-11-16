using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;


namespace Backend.Application.Interfaces
{
    public interface IOrderDbContext
    {
        DbSet<Order> Order { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
