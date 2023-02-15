using eGames.Data.Cart;
using eGames.Data.Services;
using eGames.Data.Static;
using eGames.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace eGames.Controllers
{
    [Authorize]
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
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _ordersService.GetOrdersByUserIdAndRoleAsync(userId, userRole);

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

            if (items.Count == 0)
                return RedirectToAction("CartWasEmpty");

            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmailAddress = User.FindFirstValue(ClaimTypes.Email);

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _shoppingCart.ClearShoppingCartAsync();

            return RedirectToAction("OrderCompleted");
        }

        // Zibal Sandbax
        // Full docs: https://docs.zibal.ir/IPG/API/

        private readonly string _merchentId = "zibal"; // Your merchent id
        private readonly string _callbackUrl = "https://localhost:44358/Orders/ValidatePayment"; // Your callback url
        private readonly int _dollarToIrr = 450000;

        public async Task<IActionResult> RequestPayment()
        {
            // Total amount in irr ( $1 = 450000 IRR)
            var totalAmount = (_shoppingCart.GetShoppingCartTotal() * _dollarToIrr);

            var paymentRequest = new
            {
                merchant = _merchentId,
                amount = totalAmount,
                description = $"Payment for order #{_shoppingCart.ShoppingCartId}",
                callbackUrl = _callbackUrl
            };

            // Convert the payment request object to JSON
            var json = JsonConvert.SerializeObject(paymentRequest);

            // Send a POST request to the Zibal API
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.PostAsync("https://gateway.zibal.ir/v1/request", new StringContent(json, Encoding.UTF8, "application/json"));

            // Check the response from the API
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(content);

            // Success = 100
            if (result.result == 100)
            {
                // Get the payment URL from the response
                var paymentUrl = $"https://gateway.zibal.ir/start/{result.trackId}";
                return Redirect(paymentUrl);
            }
            else
            {
                return RedirectToAction("PaymentError");
            }
        }

        public async Task<IActionResult> ValidatePayment(string trackId, string success, string status)
        {
            if (success == "1" && await VerifyPaymentWithGateway(trackId))
                return RedirectToAction("CompleteOrder");
            else
                return RedirectToAction("PaymentError");
        }

        private async Task<bool> VerifyPaymentWithGateway(string trackId)
        {
            var verifyRequest = new
            {
                merchant = _merchentId,
                trackId = trackId,
            };

            // Convert the verify request object to JSON
            var json = JsonConvert.SerializeObject(verifyRequest);

            // Send a POST request to the Zibal API
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.PostAsync("https://gateway.zibal.ir/v1/verify", new StringContent(json, Encoding.UTF8, "application/json"));

            // Check the response from the API
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<dynamic>(content);

            // Success = 100
            if (result.result == 100)
                return true;

            return false;
        }

        public IActionResult OrderCompleted()
        {
            return View();
        }

        public IActionResult PaymentError()
        {
            return View();
        }

        public IActionResult CartWasEmpty()
        {
            return View();
        }
    }
}