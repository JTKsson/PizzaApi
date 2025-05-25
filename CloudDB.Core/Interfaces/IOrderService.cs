using CloudDB.Domain.Entities;
using static CloudDB.Domain.DTO.OrderDTO;

namespace CloudDB.Core.Interfaces
{
    public interface IOrderService
    {
        Task AddOrder(OrderCreateDTO orderDto, string userId);
        Task<List<OrderGetDTO>> GetAuthUserOrders(string userId);
        Task DeleteOrder(int orderId);
    }
}
