using eGames.Models;
using Microsoft.EntityFrameworkCore;

namespace eGames.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _appDbContext { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = await _appDbContext.ShoppingCartItems
                                            .Where(cart => cart.ShoppingCartId == ShoppingCartId)
                                            .Include(cart => cart.Game).ToListAsync());
        }

        public double GetShoppingCartTotal()
        {
            return _appDbContext.ShoppingCartItems.Where(cart => cart.ShoppingCartId == ShoppingCartId)
                                            .Select(cart => cart.Game.Price * cart.Amount).Sum();
        }
    }
}