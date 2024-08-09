using BackendProyecto.Entidades;
using BackendProyecto.TuDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public class SeriesGenreRepository: ISeriesGenreRepository
    {
        private readonly TmdbContext _context;

        public SeriesGenreRepository(TmdbContext context)
        {
            _context = context;
        }

        public async Task AddSeriesGenreAsync(SeriesGenre seriesGenre)
       {
           _context.SeriesGenres.Add(seriesGenre);
           await _context.SaveChangesAsync();
       }

    }
}
