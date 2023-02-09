using eGames.Data;
using eGames.Data.Services;
using eGames.Models;
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

        // Get: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Logo", "Name", "Description")] Publisher publisher)
        {
            if (!ModelState.IsValid)
                return View(publisher);

            await _publishersService.AddAsync(publisher);
            return RedirectToAction("Index");
        }

        // Get: Publishers/Details/(id)
        public async Task<IActionResult> Details(int id)
        {
            var publisherDetails = await _publishersService.GetByIdAsync(id);

            if (publisherDetails == null)
                return View("NotFound");

            return View(publisherDetails);
        }

        // Get: Publishers/Edit(id)
        public async Task<IActionResult> Edit(int id)
        {
            var publisherDetails = await _publishersService.GetByIdAsync(id);

            if (publisherDetails == null)
                return View("NotFound");

            return View(publisherDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id", "Logo", "Name", "Description")] Publisher publisher)
        {
            if (!ModelState.IsValid)
                return View(publisher);

            await _publishersService.UpdateAsync(id, publisher);
            return RedirectToAction("Index");
        }

        // Get: Publishers/Delete(id)
        public async Task<IActionResult> Delete(int id)
        {
            var publisherDetails = await _publishersService.GetByIdAsync(id);

            if (publisherDetails == null)
                return View("NotFound");

            return View(publisherDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var publisherDetails = await _publishersService.GetByIdAsync(id);

            if (publisherDetails == null)
                return View("NotFound");

            await _publishersService.RemoveAsync(id);

            return RedirectToAction("Index");
        }
    }
}