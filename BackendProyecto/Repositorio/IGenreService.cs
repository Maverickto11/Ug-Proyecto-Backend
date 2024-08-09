using BackendProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public interface IGenreService
    {
        Task<IEnumerable<Genre>> GetGenresAsync();
        Task AddGenreToMovieAsync(int movieId, int genreId);
        Task AddGenreToSeriesAsync(int serieId, int genreId);
    }

}
