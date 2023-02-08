using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace eGames.Data.Base
{
    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _appDbContext;
        public EntityBaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(T entity)
        {
            await _appDbContext.Set<T>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
        }

        public async Task RemoveAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            EntityEntry entry = _appDbContext.Entry<T>(entity);
            entry.State = EntityState.Deleted;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entry = _appDbContext.Entry<T>(entity);
            entry.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }
    }
}