using eGames.Data;
using Microsoft.AspNetCore.Mvc;

namespace eGames.Controllers
{
    public class DevelopersController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public DevelopersController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            var data = _appDbContext.Developers.ToList();
            return View();
        }
    }
}
