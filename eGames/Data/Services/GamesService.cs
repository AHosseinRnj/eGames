using eGames.Data.Base;
using eGames.Data.ViewModels;
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
            var gameDetails = await _appDbContext.Games
                .Include(game => game.Platform)
                .Include(game => game.Publisher)
                .Include(game => game.Developers_Games).ThenInclude(game => game.Developer)
                .FirstOrDefaultAsync(game => game.Id == id);

            return gameDetails;
        }

        public async Task<NewGameDropdownsVM> GetNewGameDropdownsValuesAsync()
        {
            var response = new NewGameDropdownsVM()
            {
                Developers = await _appDbContext.Developers.OrderBy(developer => developer.FullName).ToListAsync(),
                Platforms = await _appDbContext.Platforms.OrderBy(platform => platform.Name).ToListAsync(),
                Publishers = await _appDbContext.Publishers.OrderBy(publisher => publisher.Name).ToListAsync()
            };
            return response;
        }
    }
}