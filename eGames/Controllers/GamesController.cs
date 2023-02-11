using eGames.Data;
using eGames.Data.Services;
using eGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eGames.Controllers
{
    public class GamesController : Controller
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        public IActionResult NotFound()
        {
            return View("NotFound");
        }

        private async Task SetGameDropdownsAsync()
        {
            var gameDropdownsData = await _gamesService.GetNewGameDropdownsValuesAsync();

            ViewBag.PlatformId = new SelectList(gameDropdownsData.Platforms, "Id", "Name");
            ViewBag.PublisherId = new SelectList(gameDropdownsData.Publishers, "Id", "Name");
            ViewBag.DeveloperId = new SelectList(gameDropdownsData.Developers, "Id", "FullName");
        }

        private NewGameVM MapGameDetailsToNewGameVM(Game gameDetails)
        {
            return new NewGameVM()
            {
                Id = gameDetails.Id,
                ImageURL = gameDetails.ImageURL,
                Name = gameDetails.Name,
                Description = gameDetails.Description,
                Price = gameDetails.Price,
                ReleaseDate = gameDetails.ReleaseDate,
                Category = gameDetails.Category,

                PlatformId = gameDetails.PlatformId,
                PublisherId = gameDetails.PublisherId,
                DeveloperIds = gameDetails.Developers_Games.Select(gameDeveloper => gameDeveloper.DeveloperId).ToList()
            };
        }

        public async Task<IActionResult> Index()
        {
            var allGames = await _gamesService.GetAllAsync(game => game.Platform);
            return View(allGames);
        }

        // Get: Games/Create
        public async Task<IActionResult> Create()
        {
            await SetGameDropdownsAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewGameVM newGame)
        {
            if (!ModelState.IsValid)
            {
                await SetGameDropdownsAsync();
                return View(newGame);
            }

            await _gamesService.AddNewGameAsync(newGame);
            return RedirectToAction("Index");
        }

        // Get: Games/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var gameDetails = await _gamesService.GetGameByIdAsync(id);

            if (gameDetails == null)
                return View("NotFound");

            return View(gameDetails);
        }

        // Get: Games/Edit/(id)
        public async Task<IActionResult> Edit(int id)
        {
            var gameDetails = await _gamesService.GetGameByIdAsync(id);

            if (gameDetails == null)
                return View("NotFound");

            var response = MapGameDetailsToNewGameVM(gameDetails);

            await SetGameDropdownsAsync();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewGameVM newGame)
        {
            if (!ModelState.IsValid)
            {
                await SetGameDropdownsAsync();
                return View(newGame);
            }

            await _gamesService.UpdateGameAsync(newGame);
            return RedirectToAction("Index");
        }

        // Get: Games/Delete/(id)
        public async Task<IActionResult> Delete(int id)
        {
            var gameDetails = await _gamesService.GetGameByIdAsync(id);

            if (gameDetails == null)
                return View("NotFound");

            var response = MapGameDetailsToNewGameVM(gameDetails);

            await SetGameDropdownsAsync();

            return View(response);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gameDetails = await _gamesService.GetGameByIdAsync(id);

            if (gameDetails == null)
                return View("NotFound");

            await _gamesService.RemoveGameAsync(id);

            return RedirectToAction("Index");
        }
    }
}