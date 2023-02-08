using eGames.Data.Base;
using eGames.Models;

namespace eGames.Data.Services
{
    public class PublishersService : EntityBaseRepository<Publisher>, IPublishersService
    {
        public PublishersService(AppDbContext appDbContext) : base(appDbContext) { }
    }
}