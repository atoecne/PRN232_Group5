using MyticAuraClient.DTOs.Orderdetail;

namespace MyticAuraClient.DTOs.Order
{
    public class CreateOrderDto
    {
        public string RecipientName { get; set; } = string.Empty;
        public string RecipientPhone { get; set; } = string.Empty;
        public string RecipientAddress { get; set; } = string.Empty;

        public List<CreateOrderDetailDto> OrderDetails { get; set; } = new();
    }
}
