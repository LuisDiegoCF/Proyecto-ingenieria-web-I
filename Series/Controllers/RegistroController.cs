using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Series.Data;
using Series.Model;
using System.Threading.Tasks;

namespace Series.Controllers
{
    // /api/registro
    [Route("api/[controller]")]
    [ApiController]
    public class RegistroController : ControllerBase
    {

        private readonly ApplicationDbContext _dbContext;

        public RegistroController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // /api/registro/usuario
        [HttpPost]
        public async Task<IActionResult> InsertarUsuario([FromBody] Usuario newUsuario)
        {
            if (newUsuario == null)
            {
                return BadRequest();
            }

            var usuario = await _dbContext.Usuario
                .FirstOrDefaultAsync(usuario => usuario.UserName == newUsuario.UserName);
            if (usuario != null)
            {
                return BadRequest();
            }
            try
            {
                await _dbContext.Usuario.AddAsync(newUsuario);
                await _dbContext.SaveChangesAsync();

                return Ok(newUsuario.UsuarioId);
            } 
            catch (System.Exception ex)
            {
                
            }
            return new StatusCodeResult(500);
        }
    }
}
