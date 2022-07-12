using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Series.Data;
using Series.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Series.Controllers
{
    // /api/temporada
    [Route("api/[controller]")]
    [ApiController]
    public class TemporadaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public TemporadaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // /api/temporada
        [HttpGet]
        public async Task<IActionResult> GetTemporadas()
        {
            List<Temporada> temporadas = await _dbContext.Temporada.ToListAsync(); ;
            return Ok(temporadas);
        }

    }
}
