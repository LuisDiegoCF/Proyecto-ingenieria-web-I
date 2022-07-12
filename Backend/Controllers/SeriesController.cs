using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Series.Data;
using Series.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Series.Controllers
{

    // Esta ruta es un endPoint
    // /api/series
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        // aqui me genera el repositorio
        private readonly ApplicationDbContext _dbContext;

        public SeriesController(ApplicationDbContext dbContext)
        {
            _dbContext=dbContext;
        }


        // /api/series
        [HttpGet]
        public async Task<IActionResult> GetSeries()
        {
            List<Serie> series = await _dbContext.Serie
                //.Include(serie => serie.ImagenId)
                .ToListAsync();
            return Ok(series);
        }

        // /api/series/3
        [HttpGet]
        [Route("{serieId}")]
        public async Task<IActionResult> GetSerie([FromRoute] int serieId)
        {
            var serie = await GetSerieByIdFromDb(serieId);
            if(serie == null)
            {
                return NotFound();
            }
            SignOut(serie.ToString());
            return Ok(serie);
        }

        public async Task<Serie> GetSerieByIdFromDb(int serieId)
        {
            return await _dbContext.Serie
                .FirstOrDefaultAsync(serie => serie.SerieId == serieId);
        }
    }
}
