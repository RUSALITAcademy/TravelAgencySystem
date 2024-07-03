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
        private readonly ILogger<TourController> _logger;

        public ImageController(ITourImageDbContext dbContext, ILogger<TourController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpPost("{tourId}")]
        public async Task<IActionResult> UploadImage( IFormFile file, Guid tourId)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        [HttpGet("{fileName}")]
        public IActionResult GetImage(string fileName)
        {
            try
            {
                // Логика получения изображения с сервера
                var filePath = Path.Combine("wwwroot", "images", fileName);
                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                return File(fileBytes, "image/jpeg");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        [HttpGet("tour_images/{tourId}")]
        public async Task<ActionResult<IEnumerable<TourImageDto>>> GetTourImages(Guid tourId)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        private async Task<string> SaveImageToServer(IFormFile file)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }

        [HttpGet("tour_image/{tourId}")]
        public async Task<ActionResult<TourImageDto>> GetFirstTourImage(Guid tourId)
        {
            try
            {
                var tourImage = await _dbContext.TourImage
                .Where(ti => ti.TourId == tourId)
                .Select(ti => new TourImageDto
                {
                    Id = ti.Id,
                    FileName = ti.FileName
                })
                .FirstOrDefaultAsync();

                if (tourImage == null)
                {
                    return NotFound();
                }

                return Ok(tourImage);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Произошла ошибка  - {ex}", ex);
                throw;
            }
        }
    }

    public class TourImageDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
    }
}
