using BackendProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public interface IRepositorioSeries
    {
        Task<IEnumerable<Series>> ObtenerTodasLasSeries();
        Task<Series> ObtenerSeriesPorId(int seriesId);
        Task<IEnumerable<Series>> ObtenerSeriesPorGenero(int genreId);
        // Task<Pelicula> Agregar(Pelicula movie);

        Task<Series> AddSeriesAsync(Series series);
    }
}
