using BackendProyecto.Entidades;
using BackendProyecto.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepositoriy _authService;

        public LoginController(ILoginRepositoriy authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] Usuario usuarioDto)
        {
            var usuario = await _authService.Register(usuarioDto, usuarioDto.Password);
            if (usuario == null)
            {
                return BadRequest(new { exito = false, mensaje = "No se pudo registrar el usuario." });
            }
            return Ok(new { exito = true, mensaje = "Registro exitoso!", usuario });
        }

        /*public async Task<IActionResult> Register([FromBody] Usuario usuarioDto)
        {

            var usuario = await _authService.Register(usuarioDto, usuarioDto.Password);
            if (usuario == null)
            {
                return BadRequest("No se pudo registrar el usuario.");
            }
            return Ok(usuario);
        }*/

        /* [HttpPost("login")]
         public async Task<IActionResult> Login([FromBody] Usuario loginDto)
         {
             var usuario = await _authService.Login(loginDto.Email, loginDto.Password);
             if (usuario == null)
             {
                 return Unauthorized("Credenciales inválidas.");
             }
             return Ok(usuario);
         }*/

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Usuario loginDto)
        {
            try
            {
                var usuario = await _authService.Login(loginDto.Email, loginDto.Password);
                if (usuario == null)
                {
                    return Unauthorized(new AutenticacionRespuesta { Exito = false, Mensaje = "Correo o contraseña incorrectos." });
                }
                return Ok(new AutenticacionRespuesta { Exito = true, Mensaje = "Login exitoso", Usuario = usuario });
            }
            catch (Exception ex)
            {
                // Manejar la excepción adecuadamente
                return StatusCode(500, new AutenticacionRespuesta { Exito = false, Mensaje = $"Error del servidor: {ex.Message}" });
            }
        }
    }
}
