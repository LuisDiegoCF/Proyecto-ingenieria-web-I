using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Series.Data;
using Series.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Series.Controllers
{
    // /api/usuario
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public UsuarioController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        // /api/usuario
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            List<Usuario> usuarios = await _dbContext.Usuario.ToListAsync(); ;
            return Ok(usuarios);
        }

        // POST /api/usuario/autenticacion_cliente
        [Route("autenticacion_cliente")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Usuario userInput)
        {
            string username = userInput.UserName;
            string password = userInput.Password;

            // "Hola" = "HOLA"
            // FirstOrDefaultAsync me da el primero que tenga ese nombre
            Usuario storedUser = await _dbContext.Usuario
                .FirstOrDefaultAsync(u => u.UserName == username );

            if (storedUser == null || !storedUser.Password.Equals(password))
            {
                return Unauthorized();
            }
            storedUser.Password = "";
            return Ok(storedUser);
        }

        // cargo el usuario desde aqui
        // /api/usuario/3
        [HttpGet]
        [Route("{usuarioId}")]
        public async Task<IActionResult> GetUsuarioById([FromRoute] int usuarioId)
        {
            // obtengo el usuario
            var usuario = await GetUsuarioByIdFromDb(usuarioId);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        public async Task<Usuario> GetUsuarioByIdFromDb(int usuarioId)
        {
            // Obtengo el contacto y por cada contacto incluya los telefonos, 
            return await _dbContext.Usuario
                .FirstOrDefaultAsync(usuario => usuario.UsuarioId == usuarioId);
        }
    }
}
