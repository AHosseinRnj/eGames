using eGames.Data.Base;
using eGames.Data.ViewModels;
using eGames.Models;

namespace eGames.Data.Services
{
    public interface IGamesService : IEntityBaseRepository<Game>
    {
        Task<Game> GetGameByIdAsync(int id);
        Task<NewGameDropdownsVM> GetNewGameDropdownsValuesAsync();
        Task AddNewGameAsync(NewGameVM newGameVM);
        Task UpdateGameAsync(NewGameVM newGameVM);
    }
}