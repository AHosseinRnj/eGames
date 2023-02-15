using eGames.Models;
using Microsoft.EntityFrameworkCore;

namespace eGames.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _appDbContext;
        public OrdersService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId, string userRole)
        {


            var orders = await _appDbContext.Orders.Include(order => order.OrderItems)
                                             .ThenInclude(orderItem => orderItem.Game).Include(order => order.User).ToListAsync();

            if(userRole != "Admin")
                orders = orders.Where(order => order.UserId == userId).ToList();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress,
                OrderItems = items.Select(item => new OrderItem
                {
                    Amount = item.Amount,
                    Price = item.Game.Price,
                    GameId = item.Game.Id
                }).ToList()
            };
            await _appDbContext.Orders.AddAsync(order);
            await _appDbContext.SaveChangesAsync();
        }
    }
}