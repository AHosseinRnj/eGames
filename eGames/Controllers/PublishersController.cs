using eGames.Data;
using eGames.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGames.Controllers
{
    public class PublishersController : Controller
    {
        private readonly IPublishersService _publishersService;

        public PublishersController(IPublishersService publishersService)
        {
            _publishersService = publishersService;
        }

        public async Task<IActionResult> Index()
        {
            var allPublishers = await _publishersService.GetAllAsync();
            return View(allPublishers);
        }
    }
}