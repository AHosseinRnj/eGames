using eGames.Data;
using eGames.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGames.Controllers
{
    public class PlatformsController : Controller
    {
        private readonly IPlatformsService _platformsService;

        public PlatformsController(IPlatformsService platformsService)
        {
            _platformsService = platformsService;
        }

        public async Task<IActionResult> Index()
        {
            var allPlatforms = await _platformsService.GetAllAsync();
            return View(allPlatforms);
        }
    }
}