using eGames.Data;
using eGames.Data.Services;
using eGames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGames.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly IDevelopersService _developersService;

        public DevelopersController(IDevelopersService developersService)
        {
            _developersService = developersService;
        }

        public async Task<IActionResult> Index()
        {
            var allDevelopers = await _developersService.GetDevelopersAsync();
            return View(allDevelopers);
        }

        // Get: Developers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureURL", "FullName", "Biography")] Developer developer)
        {
            if (!ModelState.IsValid)
                return View(developer);

            await _developersService.AddDeveloperAsync(developer);
            return RedirectToAction("Index");
        }

        // Get: Developers/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var developerDetails = await _developersService.GetDeveloperByIdAsync(id);

            if (developerDetails == null)
                return View("Empty");

            return View(developerDetails);
        }
    }
}