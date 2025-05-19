using CloudDB.Core.Interfaces;
using CloudDB.Domain.Entities;
using CloudDB.Infrastructure.Interfaces;
using static CloudDB.Domain.DTO.OrderDTO;

namespace CloudDB.Core.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepo _repo;

        public OrderService(IOrderRepo repo)
        {
            _repo = repo;
        }

        public async Task AddOrder(OrderCreateDTO orderDto, string userId)
        {
            await _repo.AddOrder(orderDto, userId);
        }
    }
}
