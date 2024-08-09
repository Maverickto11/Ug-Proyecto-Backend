using BackendProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMovieGenreRepository _movieGenreRepository;
        private readonly ISeriesGenreRepository _seriesGenreRepository;
        public GenreService(IGenreRepository genreRepository, IMovieGenreRepository movieGenreRepository, ISeriesGenreRepository seriesGenreRepository)
        {
            _genreRepository = genreRepository;
            _movieGenreRepository = movieGenreRepository;
            _seriesGenreRepository = seriesGenreRepository;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _genreRepository.GetGenresAsync();
        }

        public async Task AddGenreToMovieAsync(int movieId, int genreId)
        {
            var movieGenre = new MovieGenre
            {
                MovieId = movieId,
                GenreId = genreId

            };
            await _movieGenreRepository.AddMovieGenreAsync(movieGenre);
        }
        public async Task AddGenreToSeriesAsync(int serieId, int genreId)
        {
            var seriesGenre = new SeriesGenre
            {
                SeriesId = serieId,
                GenreId = genreId

            };
            await _seriesGenreRepository.AddSeriesGenreAsync(seriesGenre);
        }
    }

}
