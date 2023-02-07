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

        public async Task AddDeveloperAsync(Developer developer)
        {
            await _appDbContext.AddAsync(developer);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Developer> GetDeveloperByIdAsync(int id)
        {
            var result = await _appDbContext.Developers.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<IEnumerable<Developer>> GetDevelopersAsync()
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