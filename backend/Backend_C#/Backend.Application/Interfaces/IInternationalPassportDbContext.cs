using Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Application.Interfaces
{
    public interface IInternationalPassportDbContext
    {
        DbSet<InternationalPassport> InternationalPassport { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
