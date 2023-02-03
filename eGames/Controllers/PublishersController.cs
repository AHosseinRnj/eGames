using eGames.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGames.Controllers
{
    public class PublishersController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public PublishersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var allPublishers = await _appDbContext.Publishers.ToListAsync();
            return View();
        }
    }
}