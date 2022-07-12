using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Series.Data;
using Series.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Series.Controllers
{
    // /api/episodio
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodioController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public EpisodioController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // /api/episodio
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            List<Episodio> usuarios = await _dbContext.Episodio.ToListAsync(); ;
            return Ok(usuarios);
        }
    }
}
