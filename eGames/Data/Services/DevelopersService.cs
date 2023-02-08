using eGames.Data.Base;
using eGames.Models;
using Microsoft.EntityFrameworkCore;

namespace eGames.Data.Services
{
    public class DevelopersService : EntityBaseRepository<Developer>, IDevelopersService
    {
        public DevelopersService(AppDbContext appDbContext) : base(appDbContext) { }
    }
}