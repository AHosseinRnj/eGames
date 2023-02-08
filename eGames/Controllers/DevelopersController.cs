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
            var allDevelopers = await _developersService.GetAllAsync();
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

            await _developersService.AddAsync(developer);
            return RedirectToAction("Index");
        }

        // Get: Developers/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var developerDetails = await _developersService.GetByIdAsync(id);

            if (developerDetails == null)
                return View("NotFound");

            return View(developerDetails);
        }

        // Get: Developers/Edit(id)
        public async Task<IActionResult> Edit(int id)
        {
            var developerDetails = await _developersService.GetByIdAsync(id);

            if (developerDetails == null)
                return View("NotFound");

            return View(developerDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "ProfilePictureURL", "FullName", "Biography")] Developer developer)
        {
            if (!ModelState.IsValid)
                return View(developer);

            await _developersService.UpdateAsync(id, developer);
            return RedirectToAction("Index");
        }

        // Get: Developers/Delete(id)
        public async Task<IActionResult> Delete(int id)
        {
            var developerDetails = await _developersService.GetByIdAsync(id);

            if (developerDetails == null)
                return View("NotFound");

            return View(developerDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var developerDetails = await _developersService.GetByIdAsync(id);

            if (developerDetails == null)
                return View("NotFound");

            await _developersService.RemoveAsync(id);

            return RedirectToAction("Index");
        }
    }
}