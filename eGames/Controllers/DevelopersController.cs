using eGames.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eGames.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DevelopersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _appDbContext.Developers.ToListAsync();
            return View();
        }
    }
}