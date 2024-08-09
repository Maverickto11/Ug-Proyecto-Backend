using BackendProyecto.Entidades;
using BackendProyecto.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly IRepositorioSeries _repositorioSeries;

        public SeriesController(IRepositorioSeries repositorioSeries)
        {
            _repositorioSeries = repositorioSeries;
        }

        // GET: api/Series
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Series>>> ObtenerTodasLasSeries()
        {
            var series = await _repositorioSeries.ObtenerTodasLasSeries();
            return Ok(series);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Series>> ObtenerSeriesPorId(int id)
        {
            var series = await _repositorioSeries.ObtenerSeriesPorId(id);

            if (series == null)
            {
                return NotFound();
            }

            return Ok(series);
        }

        [HttpGet("Genero/{idGenero}")]
        public async Task<ActionResult<IEnumerable<Series>>> ObtenerSeriesPorGenero(int idGenero)
        {
            var series = await _repositorioSeries.ObtenerSeriesPorGenero(idGenero);
            return Ok(series);
        }

        [HttpPost]
        public async Task<ActionResult<Series>> Agregar([FromBody] Series series)
        {
            await _repositorioSeries.AddSeriesAsync(series);
            return CreatedAtAction("ObtenerSeriesPorId", new { id = series.SeriesId }, series);
        }
    }
}
