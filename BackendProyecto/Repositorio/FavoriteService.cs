using BackendProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoriteService(IFavoriteRepository favoriteRepository)
        {
            _favoriteRepository = favoriteRepository;
        }

        public Task<IEnumerable<Favorite>> GetFavoritesByUserId(int userId)
        {
            return _favoriteRepository.GetFavoritesByUserId(userId);
        }

        public Task<Favorite> AddFavorite(Favorite favorite)
        {
            return _favoriteRepository.AddFavorite(favorite);
        }

        public Task<bool> RemoveFavorite(int userId, int movieId)
        {
            return _favoriteRepository.RemoveFavorite(userId, movieId);
        }
    }
}