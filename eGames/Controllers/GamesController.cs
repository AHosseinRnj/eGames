using eGames.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGames.Controllers
{
    public class GamesController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public GamesController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult NotFound()
        {
            return View("NotFound");
        }

        public async Task<IActionResult> Index()
        {
            var allGames = await _appDbContext.Games.Include(p => p.Platform).OrderBy(p => p.Name).ToListAsync();
            return View(allGames);
        }
    }
}