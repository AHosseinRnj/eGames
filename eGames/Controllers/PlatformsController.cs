using eGames.Data;
using eGames.Data.Services;
using eGames.Data.Static;
using eGames.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGames.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class PlatformsController : Controller
    {
        private readonly IPlatformsService _platformsService;

        public PlatformsController(IPlatformsService platformsService)
        {
            _platformsService = platformsService;
        }

        [AllowAnonymous]
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
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var PlatformDetails = await _platformsService.GetByIdAsync(id);

            if (PlatformDetails == null)
                return View("NotFound");

            return View(PlatformDetails);
        }

        // Get: Platforms/Edit(id)
        public async Task<IActionResult> Edit(int id)
        {
            var PlatformDetails = await _platformsService.GetByIdAsync(id);

            if (PlatformDetails == null)
                return View("NotFound");

            return View(PlatformDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Logo", "Name", "URL", "Description")] Platform platform)
        {
            if (!ModelState.IsValid)
                return View(platform);

            await _platformsService.UpdateAsync(id, platform);
            return RedirectToAction("Index");
        }

        // Get: Platforms/Delete(id)
        public async Task<IActionResult> Delete(int id)
        {
            var PlatformDetails = await _platformsService.GetByIdAsync(id);

            if (PlatformDetails == null)
                return View("NotFound");

            return View(PlatformDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var PlatformDetails = await _platformsService.GetByIdAsync(id);

            if (PlatformDetails == null)
                return View("NotFound");

            await _platformsService.RemoveAsync(id);

            return RedirectToAction("Index");
        }
    }
}