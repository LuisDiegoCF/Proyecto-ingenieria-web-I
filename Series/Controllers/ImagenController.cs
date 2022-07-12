using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Series.Data;
using Series.Model;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Series.Controllers
{
    // Esta ruta es un endPoint
    // /api/imagen
    [Route("api/[controller]")]
    [ApiController]
    public class ImagenController : Controller
    {
        // aqui me genera el repositorio
        private readonly ApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public ImagenController(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        // /api/imagen
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var imageId = 0;
            var fileContent = ContentDispositionHeaderValue.Parse(file.ContentDisposition);
            var fileName = Path.GetFileName(fileContent.FileName);
            var randomFileName = Guid.NewGuid().ToString() + Path.GetRandomFileName();
            var folderPath = _configuration["ApplicationFilesPath"];

            var filePath = folderPath + randomFileName;

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);

                Imagen img = new Imagen()
                {
                    FechaSubida = DateTime.Now,
                    Path = filePath,
                    Temporal = true,
                    FileName = fileName
                };

                await _dbContext.Imagen.AddAsync(img);
                await _dbContext.SaveChangesAsync();

                imageId = img.ImagenId;
            }

            return Ok(imageId);
        }

        // /api/imagen/1
        [HttpGet]
        [Route("{imageId}")]
        public async Task<IActionResult> GetImage(int imageId)
        {
            Imagen img = await _dbContext.Imagen.FirstOrDefaultAsync(image => image.ImagenId == imageId);
            if (img == null)
            {
                return NotFound();
            }
            byte[] imageContent = System.IO.File.ReadAllBytes(img.Path);
            return File(imageContent, GetMimeType(img.FileName));
        }

        private string GetMimeType(string fileName)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(fileName, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}
