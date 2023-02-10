using eGames.Data.Base;
using eGames.Models;

namespace eGames.Data.Services
{
    public class GamesService : EntityBaseRepository<Game>, IGamesService
    {
        public GamesService(AppDbContext appDbContext) : base(appDbContext) { }
    }
}