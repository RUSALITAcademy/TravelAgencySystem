using Backend.Application.Interfaces;
using Backend.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.WebAPI.Controllers
{
    [Route("api/images")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ITourImageDbContext _dbContext;

        public ImageController(ITourImageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file, Guid tourId)
        {
            // Логика загрузки изображения на сервер
            var fileName = await SaveImageToServer(file);

            // Сохранение информации об изображении в базе данных
            var tourImage = new TourImage
            {
                Id = Guid.NewGuid(),
                TourId = tourId, // Замените на реальный TourId
                FileName = fileName
            };
            await _dbContext.TourImage.AddAsync(tourImage);
            await _dbContext.SaveChangesAsync(CancellationToken.None);

            return Ok(fileName);
        }

        [HttpGet("{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            // Логика получения изображения с сервера
            var filePath = Path.Combine("wwwroot", "images", fileName);
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "image/jpeg");
        }

        [HttpGet("tour_images/{tourId}")]
        public async Task<ActionResult<IEnumerable<TourImageDto>>> GetTourImages(Guid tourId)
        {
            var tourImages = await _dbContext.TourImage
                .Where(ti => ti.TourId == tourId)
                .Select(ti => new TourImageDto
                {
                    Id = ti.Id,
                    FileName = ti.FileName
                })
                .ToListAsync();

            return Ok(tourImages);
        }

        private async Task<string> SaveImageToServer(IFormFile file)
        {
            // Логика сохранения изображения на сервере
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine("wwwroot", "images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return fileName;
        }
    }

    public class TourImageDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
    }
}
