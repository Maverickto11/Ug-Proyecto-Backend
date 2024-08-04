using BackendProyecto.Entidades;
using BackendProyecto.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genre>>> GetGenres()
        {
            var genres = await _genreService.GetGenresAsync();
            return Ok(genres);
        }

        [HttpPost("{movieId}/genres")]   
        public async Task<ActionResult> AddGenreToMovie(int movieId, [FromBody] int genreId)
        {
            if (genreId <= 0)
            {
                return BadRequest("Invalid genre ID.");
            }
            await _genreService.AddGenreToMovieAsync(movieId, genreId);
            return NoContent();
        }


    }

}
