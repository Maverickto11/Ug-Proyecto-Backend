using BackendProyecto.Entidades;
using BackendProyecto.TuDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendProyecto.Repositorio
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly TmdbContext _context;

        public FavoriteRepository(TmdbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Favorite>> GetFavorites()
        {
            return await _context.Favorites.ToListAsync();
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesByUserId(int userId)
        {
            return await _context.Favorites.Where(f => f.UserId == userId).ToListAsync();
        }

        public async Task<Favorite> AddFavorite(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
            await _context.SaveChangesAsync();
            return favorite;
        }

        public async Task<bool> RemoveFavorite(int userId, int movieId)
        {
            var favorite = await _context.Favorites.FirstOrDefaultAsync(f => f.UserId == userId && f.MovieId == movieId);
            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

