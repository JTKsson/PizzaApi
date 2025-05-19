using CloudDB.Domain.Entities;
using CloudDB.Infrastructure.Identity;
using CloudDB.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using static CloudDB.Domain.DTO.OrderDTO;

namespace CloudDB.Infrastructure.Repos
{
    public class OrderRepo : IOrderRepo
    {

        private readonly ApplicationUserContext _context;

        public OrderRepo(ApplicationUserContext context)
        {
            _context = context;
        }

        public async Task AddOrder(OrderCreateDTO orderDto, string userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new ArgumentException($"No user found with ID {userId}");

            // Fetch products by IDs
            var products = await _context.Products
                .Where(p => orderDto.ProductIds.Contains(p.ProductId))
                .ToListAsync();

            // Calculate total price
            var totalPrice = products.Sum(p => p.ProductPrice);

            // Map DTO to Order entity
            var order = new Order
            {
                User = user,
                Products = products,
                TotalPrice = totalPrice
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }
    }
}
