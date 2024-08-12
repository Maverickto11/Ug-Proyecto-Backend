using BackendProyecto.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public interface IFavoriteRepository
    {
        Task<IEnumerable<Favorite>> GetFavorites();
        Task<IEnumerable<Favorite>> GetFavoritesByUserId(int userId);
        Task<Favorite> AddFavorite(Favorite favorite);
        Task<bool> RemoveFavorite(int userId, int movieId);
    }
}
