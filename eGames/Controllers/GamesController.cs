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

        //[HttpPost]
        //public async Task<IActionResult> Create([Bind("ImageURL", "Name", "Description", "Price", "ReleaseDate", "Category")] Game game)
        //{
        //    if (!ModelState.IsValid)
        //        return View(game);

        //    await _gamesService.AddAsync(game);
        //    return RedirectToAction("Index");
        //}

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