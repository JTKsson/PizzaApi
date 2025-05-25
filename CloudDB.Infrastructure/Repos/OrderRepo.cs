using CloudDB.Domain.DTO;
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
            if (user == null) throw new ArgumentException($"No user found with ID {userId}");

            var products = await _context.Products
                .Where(p => orderDto.ProductIds.Contains(p.ProductId))
                .ToListAsync();

            var totalPrice = products.Sum(p => p.ProductPrice);

            var order = new Order
            {
                User = user,
                Products = products,
                TotalPrice = totalPrice
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task AddPremiumOrder(OrderCreateDTO orderDto, string userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user == null) throw new ArgumentException($"No user found with ID {userId}");

            var products = await _context.Products
                .Where(p => orderDto.ProductIds.Contains(p.ProductId))
                .ToListAsync();

            var totalProducts = products.Count;
            var totalPrice = products.Sum(p => p.ProductPrice);

            if (user.BenefitPoints >= 100 && products.Any())
            {
                var minProductPrice = products.Min(p => p.ProductPrice);
                totalPrice -= minProductPrice;
                user.BenefitPoints -= 100;
            }

            if (totalProducts >= 3)
            {
                totalPrice = (int)(totalPrice * 0.8);
            }

            if (totalPrice < 0) totalPrice = 0;

            user.BenefitPoints += totalProducts * 10;

            var order = new Order
            {
                User = user,
                Products = products,
                TotalPrice = totalPrice
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }


        public async Task<List<OrderGetDTO>> GetAuthUserOrders(string userId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == userId);
            if (user == null) throw new ArgumentException($"No user found with ID {userId}");

            var orders = await _context.Orders
                .Where(o => o.User == user)
                .Include(o => o.Products)
                .AsNoTracking()
                .ToListAsync();

            var orderDtos = orders.Select(o => new OrderGetDTO
            {
                TotalPrice = o.TotalPrice,
                Products = o.Products.Select(p => new ProductGetDTO
                {
                    ProductName = p.ProductName,
                    ProductPrice = p.ProductPrice
                }).ToList()
            }).ToList();

            return orderDtos;
        }

    }
}
