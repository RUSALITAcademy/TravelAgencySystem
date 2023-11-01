namespace Backend.Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        //что-то про паспорт вопрос у Никиты возник


        public List<Order>? Orders { get; set; } // Связь с Order, один ко многим
    }
}
