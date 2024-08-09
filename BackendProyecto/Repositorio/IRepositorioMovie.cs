using BackendProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public interface IRepositorioMovie
    {
        Task<IEnumerable<Movie>> ObtenerTodasLasPeliculas();
        Task<Movie> ObtenerPeliculaPorId(int movieId);
        Task<IEnumerable<Movie>> ObtenerPeliculasPorGenero(int genreId);
       // Task<Pelicula> Agregar(Pelicula movie);

        Task<Movie> AddPeliculaAsync(Movie pelicula);

    }
}
