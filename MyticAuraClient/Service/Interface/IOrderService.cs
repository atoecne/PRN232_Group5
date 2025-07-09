using MyticAuraClient.DTOs.Order;
using MyticAuraClient.DTOs.Orderdetail;

namespace MyticAuraClient.Service.Interface
{
    public interface IOrderService
    {
        Task<List<ReadOrderDto>> GetOrdersByUserAsync(Guid userId);
        Task<ReadOrderDto> CreateOrderAsync(CreateOrderDto dto);
        Task<List<ReadOrderDetailDto>> GetOrderDetailsAsync(Guid orderId);
        Task ConfirmOrderAsync(Guid orderId);
        Task CancelOrderAsync(Guid orderId);
    }
}
