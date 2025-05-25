using CloudDB.Domain.Entities;
using static CloudDB.Domain.DTO.OrderDTO;

namespace CloudDB.Infrastructure.Interfaces
{
    public interface IOrderRepo
    {
        Task AddOrder(OrderCreateDTO orderDto, string userId);
        Task AddPremiumOrder(OrderCreateDTO orderDto, string userId);
        Task<List<OrderGetDTO>> GetAuthUserOrders (string userId);
        Task RemoveOrder(int orderId);
        Task ChangeOrderStatus(int orderId, bool isDelivered);
    }
}
