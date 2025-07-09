using MyticAuraClient.DTOs.Orderdetail;

namespace MyticAuraClient.Service.Interface
{
    public interface IOrderdetailService
    {
        Task<List<ReadOrderDetailDto>> GetByOrderIdAsync(Guid orderId);
    }
}
