namespace Backend.Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ImgUrl { get; set; }

        public Passport Passport { get; set; }
        public InternationalPassport InternationalPassport { get; set; }

        public List<Order>? Orders { get; set; } // Связь с Order, один ко многим
    }
}
