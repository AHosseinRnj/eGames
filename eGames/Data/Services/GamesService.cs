using eGames.Data.Base;
using eGames.Models;
using Microsoft.EntityFrameworkCore;

namespace eGames.Data.Services
{
    public class GamesService : EntityBaseRepository<Game>, IGamesService
    {
        private readonly AppDbContext _appDbContext;
        public GamesService(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            var movieDetails = await _appDbContext.Games
                .Include(game => game.Platform)
                .Include(game => game.Publisher)
                .Include(game => game.Developers_Games).ThenInclude(game => game.Developer)
                .FirstOrDefaultAsync(game => game.Id == id);

            return movieDetails;
        }
    }
}