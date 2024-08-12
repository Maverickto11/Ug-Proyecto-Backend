using BackendProyecto.Entidades;
using BackendProyecto.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComentarioController : ControllerBase
    {
        private readonly IComentarioRepository _comentarioRepository;

        public ComentarioController(IComentarioRepository comentarioRepository)
        {
            _comentarioRepository = comentarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetComentarios()
        {
            var comentarios = await _comentarioRepository.GetComentariosAsync();
            return Ok(comentarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComentario(int id)
        {
            var comentario = await _comentarioRepository.GetComentarioByIdAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            return Ok(comentario);
        }

        [HttpPost]
        public async Task<IActionResult> AddComentario([FromBody] Comentario comentario)
        {
            await _comentarioRepository.AddComentarioAsync(comentario);
            return CreatedAtAction(nameof(GetComentario), new { id = comentario.Id }, comentario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComentario(int id, [FromBody] Comentario comentario)
        {
            if (id != comentario.Id)
            {
                return BadRequest();
            }

            await _comentarioRepository.UpdateComentarioAsync(comentario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            await _comentarioRepository.DeleteComentarioAsync(id);
            return NoContent();
        }
    }

}
