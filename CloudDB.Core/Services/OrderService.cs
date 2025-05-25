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

        public async Task AddPremiumOrder(OrderCreateDTO orderDto, string userId)
        {
            await _repo.AddPremiumOrder(orderDto, userId);
        }


        public async Task<List<OrderGetDTO>> GetAuthUserOrders(string userId)
        {
            return await _repo.GetAuthUserOrders(userId);            
        }

        public async Task RemoveOrder(int orderId)
        {
            await _repo.RemoveOrder(orderId);
        }

        public async Task ChangeOrderStatus(int orderId, bool isDelivered)
        {
            await _repo.ChangeOrderStatus(orderId, isDelivered);
        }
    }
}
