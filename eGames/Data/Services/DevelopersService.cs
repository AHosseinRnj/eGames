using eGames.Models;
using Microsoft.EntityFrameworkCore;

namespace eGames.Data.Services
{
    public class DevelopersService : IDevelopersService
    {
        private readonly AppDbContext _appDbContext;

        public DevelopersService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddDeveloper(Developer developer)
        {
            _appDbContext.Add(developer);
            _appDbContext.SaveChanges();
        }

        public Developer GetDeveloperById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Developer>> GetDevelopers()
        {
            var result = await _appDbContext.Developers.ToListAsync();
            return result;
        }

        public void RemoveDeveloper(int id)
        {
            throw new NotImplementedException();
        }

        public Developer UpdateDeveloper(int id, Developer newDeveloper)
        {
            throw new NotImplementedException();
        }
    }
}