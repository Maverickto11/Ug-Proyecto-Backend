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

        public GenreService(IGenreRepository genreRepository, IMovieGenreRepository movieGenreRepository)
        {
            _genreRepository = genreRepository;
            _movieGenreRepository = movieGenreRepository;
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
    }

}
