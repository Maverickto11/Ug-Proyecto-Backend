using BackendProyecto.Entidades;
using BackendProyecto.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;

        public FavoritesController(IFavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetFavorites()
        {
            var favorites = await _favoriteService.GetFavorites();
            return Ok(favorites);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetFavoritesByUserId(int userId)
        {
            var favorites = await _favoriteService.GetFavoritesByUserId(userId);
            return Ok(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite([FromBody] Favorite favorite)
        {
            var addedFavorite = await _favoriteService.AddFavorite(favorite);
            return CreatedAtAction(nameof(GetFavoritesByUserId), new { userId = addedFavorite.UserId }, addedFavorite);
        }

        [HttpDelete("{userId}/{movieId}")]
        public async Task<IActionResult> RemoveFavorite(int userId, int movieId)
        {
            var success = await _favoriteService.RemoveFavorite(userId, movieId);
            if (success)
            {
                return NoContent();
            }
            return NotFound();
        }
    }
}
