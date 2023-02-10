using eGames.Data.Base;
using eGames.Models;

namespace eGames.Data.Services
{
    public interface IGamesService : IEntityBaseRepository<Game>
    {
        Task<Game> GetGameByIdAsync(int id);
    }
}