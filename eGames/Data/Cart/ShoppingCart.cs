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

        public static ShoppingCart GetShoppingCart(IServiceProvider serviceProvider)
        {
            ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session ?? 
                                                throw new InvalidOperationException("HttpContextAccessor or Session not available");

            var context = serviceProvider.GetService<AppDbContext>() ??
                                                throw new InvalidOperationException("AppDbContext not available");

            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public async Task AddItemToCartAsync(Game game)
        {
            var shoppingCartItem = await _appDbContext.ShoppingCartItems
                                            .FirstOrDefaultAsync(cart => cart.Game.Id == game.Id && cart.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Game = game,
                    Amount = 1
                };

                await _appDbContext.ShoppingCartItems.AddAsync(shoppingCartItem);
            }
            else
                shoppingCartItem.Amount++;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task RemoveItemFromCartAsync(Game game)
        {
            var shoppingCartItem = await _appDbContext.ShoppingCartItems
                                .FirstOrDefaultAsync(cart => cart.Game.Id == game.Id && cart.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                    shoppingCartItem.Amount--;
                else
                    _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }

            await _appDbContext.SaveChangesAsync();
        }

        public async Task ClearShoppingCartAsync()
        {
            var items = await _appDbContext.ShoppingCartItems
                                            .Where(cart => cart.ShoppingCartId == ShoppingCartId).ToListAsync();

            _appDbContext.ShoppingCartItems.RemoveRange(items);
            await _appDbContext.SaveChangesAsync();
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