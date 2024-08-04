using BackendProyecto.Entidades;
using BackendProyecto.TuDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public class MovieGenreRepository : IMovieGenreRepository
    {
        private readonly TmdbContext _context;

        public MovieGenreRepository(TmdbContext context)
        {
            _context = context;
        }

        public async Task AddMovieGenreAsync(MovieGenre movieGenre)
        {
            _context.MovieGenres.Add(movieGenre);
            await _context.SaveChangesAsync();
        }
    }

}
