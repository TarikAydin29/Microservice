using CasgemMicroservice.PhotoStock.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservice.PhotoStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoStocksController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SavePhoto(IFormFile file, CancellationToken cancellationToken)
        {
            if (file != null && file.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Photos", file.FileName);
                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream, cancellationToken);
                var returnPath = file.FileName;
                PhotoDto dto = new PhotoDto
                {
                    Url = returnPath
                };
                return Ok("Fotoğraf Kaydedildi.");
            }
            return NoContent();
        }
    }
}
