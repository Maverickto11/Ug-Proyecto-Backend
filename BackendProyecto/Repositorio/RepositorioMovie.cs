using BackendProyecto.Entidades;
using BackendProyecto.TuDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public class RepositorioMovie : IRepositorioMovie
    {
        private readonly TmdbContext _contexto;

        public RepositorioMovie(TmdbContext contexto)
        {
            _contexto = contexto;
        }   

        public async Task<IEnumerable<Movie>> ObtenerTodasLasPeliculas()
        {
            //return await _contexto.Movies.ToListAsync();

            return await _contexto.Set<Movie>()
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre) // Si tienes una entidad Genre relacionada
                .ToListAsync();
        }

        public async Task<Movie> ObtenerPeliculaPorId(int movieId)
        {
            return await _contexto.Set<Movie>()
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre) // Si tienes una entidad Genre relacionada
                .FirstOrDefaultAsync(m => m.MovieId == movieId);
        }
        public async Task<IEnumerable<Movie>> ObtenerPeliculasPorGenero(int genreId)
        {
            return await _contexto.Set<Movie>()
                .Where(m => m.MovieGenres.Any(mg => mg.GenreId == genreId))
                .Include(m => m.MovieGenres)
                .ThenInclude(mg => mg.Genre) // Si tienes una entidad Genre relacionada
                .ToListAsync();
        }
        public async Task<Movie> AddPeliculaAsync(Movie movie)
        {
            _contexto.Set<Movie>().Add(movie);
            await _contexto.SaveChangesAsync();
            return movie;
        }
    }
}
