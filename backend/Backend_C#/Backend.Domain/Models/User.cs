using Microsoft.AspNetCore.Identity;

namespace Backend.Domain.Models
{
    public class User: IdentityUser
    {
        public string? ImgUrl { get; set; }

        public List<Order>? Orders { get; set; } // Связь с Order, один ко многим
    }
}
