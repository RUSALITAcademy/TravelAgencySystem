
namespace Backend.Domain.Models
{
    public class TourImage
    {
        public Guid Id { get; set; }
        public Tour Tour { get; set; }
        public Guid TourId { get; set; }
        public string FileName { get; set; }
    }
}
