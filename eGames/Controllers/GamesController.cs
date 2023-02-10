using eGames.Data;
using eGames.Data.Services;
using eGames.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create()
        {
            return View();
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