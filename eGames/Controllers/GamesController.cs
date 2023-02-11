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

        private async Task SetGameDropdownsAsync()
        {
            var gameDropdownsData = await _gamesService.GetNewGameDropdownsValuesAsync();

            ViewBag.PlatformId = new SelectList(gameDropdownsData.Platforms, "Id", "Name");
            ViewBag.PublisherId = new SelectList(gameDropdownsData.Publishers, "Id", "Name");
            ViewBag.DeveloperId = new SelectList(gameDropdownsData.Developers, "Id", "FullName");
        }

        // Get: Games/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var gameDetails = await _gamesService.GetGameByIdAsync(id);

            if (gameDetails == null)
                return View("NotFound");

            return View(gameDetails);
        }
    }
}