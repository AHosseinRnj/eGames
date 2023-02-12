using eGames.Data.Cart;
using eGames.Data.Services;
using eGames.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eGames.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IGamesService _gamesService;
        private readonly ShoppingCart _shoppingCart;

        public OrdersController(IGamesService gamesService, ShoppingCart shoppingCart)
        {
            _gamesService = gamesService;
            _shoppingCart = shoppingCart;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _shoppingCart.GetShoppingCartItemsAsync();
            _shoppingCart.ShoppingCartItems = items;

            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }
    }
}