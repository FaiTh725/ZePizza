using Profile.Domain.Abstractions.Repositories;
using Profile.Domain.Entities;

namespace Profile.API.Dal.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<Order> AddOrder(Order order)
        {
            var newOrder = await context.Orders.AddAsync(order);
        
            await context.SaveChangesAsync();

            return newOrder.Entity;
        }
    }
}
