using eGames.Models;

namespace eGames.Data.Services
{
    public interface IDevelopersService
    {
        Task<IEnumerable<Developer>> GetDevelopers();
        Developer GetDeveloperById(int id);
        void AddDeveloper(Developer developer);
        void RemoveDeveloper(int id);
        Developer UpdateDeveloper(int id, Developer newDeveloper);
    }
}