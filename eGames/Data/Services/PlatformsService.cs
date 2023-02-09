using eGames.Data.Base;
using eGames.Models;

namespace eGames.Data.Services
{
    public class PlatformsService : EntityBaseRepository<Platform>, IPlatformsService
    {
        public PlatformsService(AppDbContext appDbContext) : base(appDbContext) { }
    }
}