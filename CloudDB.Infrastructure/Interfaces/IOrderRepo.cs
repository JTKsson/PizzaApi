using CloudDB.Domain.Entities;
using static CloudDB.Domain.DTO.OrderDTO;

namespace CloudDB.Infrastructure.Interfaces
{
    public interface IOrderRepo
    {
        Task AddOrder(OrderCreateDTO order, string userId);
        Task<List<OrderGetDTO>> GetAuthUserOrders (string userId);
    }
}
