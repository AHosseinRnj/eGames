using eGames.Models;

namespace eGames.Data.Services
{
    public interface IDevelopersService
    {
        Task<IEnumerable<Developer>> GetDevelopersAsync();
        Task<Developer> GetDeveloperByIdAsync(int id);
        Task AddDeveloperAsync(Developer developer);
        void RemoveDeveloper(int id);
        Task<Developer> UpdateDeveloperAsync(int id, Developer newDeveloper);
    }
}