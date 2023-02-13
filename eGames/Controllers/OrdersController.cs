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
        private readonly IOrdersService _ordersService;

        public OrdersController(IGamesService gamesService, ShoppingCart shoppingCart, IOrdersService ordersService)
        {
            _gamesService = gamesService;
            _shoppingCart = shoppingCart;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            // Empty for now
            string userId = "";

            var orders = await _ordersService.GetOrdersByUserIdAsync(userId);

            return View(orders);
        } 

        public async Task<IActionResult> ShoppingCart()
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

        public async Task<RedirectToActionResult> AddToShoppingCart(int id)
        {
            var item = await _gamesService.GetGameByIdAsync(id);

            if (item != null)
                await _shoppingCart.AddItemToCartAsync(item);

            return RedirectToAction("ShoppingCart");
        }

        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int id)
        {
            var item = await _gamesService.GetGameByIdAsync(id);

            if (item != null)
                await _shoppingCart.RemoveItemFromCartAsync(item);

            return RedirectToAction("ShoppingCart");
        }

        public async Task<RedirectToActionResult> CompleteOrder()
        {
            var items = await _shoppingCart.GetShoppingCartItemsAsync();

            // Empty for now
            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return RedirectToAction("OrderCompleted");
        }

        public IActionResult OrderCompleted()
        {
            return View();
        }
    }
}