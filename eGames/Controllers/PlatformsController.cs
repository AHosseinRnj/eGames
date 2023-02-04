using eGames.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGames.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public PlatformsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;   
        }

        public async Task<IActionResult> Index()
        {
            var allPlatforms = await _appDbContext.Platforms.ToListAsync();
            return View(allPlatforms);
        }
    }
}