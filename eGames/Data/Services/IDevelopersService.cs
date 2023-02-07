using eGames.Models;

namespace eGames.Data.Services
{
    public interface IDevelopersService
    {
        Task<IEnumerable<Developer>> GetDevelopersAsync();
        Task<Developer> GetDeveloperByIdAsync(int id);
        Task AddDeveloperAsync(Developer developer);
        void RemoveDeveloper(int id);
        Developer UpdateDeveloper(int id, Developer newDeveloper);
    }
}