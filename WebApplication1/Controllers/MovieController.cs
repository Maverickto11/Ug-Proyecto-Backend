using BackendProyecto.Entidades;
using BackendProyecto.Repositorio;
using BackendProyecto.TuDbContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IRepositorioMovie _repositorioPeliculas;

        public MovieController(IRepositorioMovie repositorioPeliculas)
        {
            _repositorioPeliculas = repositorioPeliculas;
        }

        // GET: api/Movie
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> ObtenerTodasLasPeliculas()
        {
            var peliculas = await _repositorioPeliculas.ObtenerTodasLasPeliculas();
            return Ok(peliculas);
        }

        // GET: api/Movie/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> ObtenerPeliculaPorId(int id)
        {
            var pelicula = await _repositorioPeliculas.ObtenerPeliculaPorId(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return Ok(pelicula);
        }

        // GET: api/Movie/Genero/{idGenero}
        [HttpGet("Genero/{idGenero}")]
        public async Task<ActionResult<IEnumerable<Movie>>> ObtenerPeliculasPorGenero(int idGenero)
        {
            var peliculas = await _repositorioPeliculas.ObtenerPeliculasPorGenero(idGenero);
            return Ok(peliculas);
        }   

        // POST: api/Movie
        [HttpPost]
        public async Task<ActionResult<Movie>> Agregar([FromBody] Movie pelicula)
        {
            await _repositorioPeliculas.AddPeliculaAsync(pelicula);
            return CreatedAtAction("ObtenerPeliculaPorId", new { id = pelicula.MovieId }, pelicula);
        }
    }
}
//Task<ActionResult<Movie>>
       /* [HttpPost]
        public async Task<IActionResult> PostPelicula([FromBody] Pelicula peliculaData)
        {
            if (peliculaData == null || string.IsNullOrEmpty(peliculaData.Title) || string.IsNullOrEmpty(peliculaData.Overview))
            {
                return BadRequest("Title and Overview are required.");
            }

            var pelicula = new Pelicula
            {
                Title = peliculaData.Title,
                Overview = peliculaData.Overview
            };

            var createdPelicula = await _repositorioPeliculas.AddPeliculaAsync(pelicula);

            return CreatedAtAction(nameof(PostPelicula), new { id = createdPelicula.MovieId }, createdPelicula);
        }*/





