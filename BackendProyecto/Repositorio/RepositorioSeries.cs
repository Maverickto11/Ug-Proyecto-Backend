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
    public class RepositorioSeries: IRepositorioSeries
    {
        private readonly TmdbContext _contexto;

        public RepositorioSeries(TmdbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Series>> ObtenerTodasLasSeries()
        {
            //return await _contexto.Movies.ToListAsync();

            return await _contexto.Set<Series>()
               .Include(s => s.SeriesGenres)
               .ThenInclude(sg => sg.Genre) // Si tienes una entidad Genre relacionada
                .ToListAsync();
        }

        public async Task<Series> ObtenerSeriesPorId(int seriesId)
        {
            return await _contexto.Set<Series>()
            .Include(s => s.SeriesGenres)
            .ThenInclude(sg => sg.Genre)
            .FirstOrDefaultAsync(s => s.SeriesId == seriesId);
        }
        public async Task<IEnumerable<Series>> ObtenerSeriesPorGenero(int genreId)
        {
            return await _contexto.Set<Series>()
            .Where(s => s.SeriesGenres.Any(sg => sg.GenreId == genreId))
            .Include(s => s.SeriesGenres)
            .ThenInclude(sg => sg.Genre)
            .ToListAsync();
        }

        public async Task<Series> AddSeriesAsync(Series series)
        {
            _contexto.Set<Series>().Add(series);
            await _contexto.SaveChangesAsync();
            return series;
        }
    }
}
