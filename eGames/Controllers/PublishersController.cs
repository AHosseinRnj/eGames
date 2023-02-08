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

        // Get: Publishers/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var publisherDetails = await _publishersService.GetByIdAsync(id);

            if (publisherDetails == null)
                return View("NotFound");

            return View(publisherDetails);
        }
    }
}