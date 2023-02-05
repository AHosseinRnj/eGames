using eGames.Data;
using eGames.Data.Services;
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
            var allDevelopers = await _developersService.GetDevelopers();
            return View(allDevelopers);
        }
    }
}