using eGames.Data;
using eGames.Data.Services;
using eGames.Models;
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

        // Get: Platforms/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo", "Name", "URL", "Description")] Platform platform)
        {
            if (!ModelState.IsValid)
                return View(platform);

            await _platformsService.AddAsync(platform);
            return RedirectToAction("Index");
        }

        // Get: Platforms/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var PlatformDetails = await _platformsService.GetByIdAsync(id);

            if (PlatformDetails == null)
                return View("NotFound");

            return View(PlatformDetails);
        }
    }
}