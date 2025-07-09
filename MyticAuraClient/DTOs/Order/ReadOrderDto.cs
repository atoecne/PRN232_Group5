using MyticAuraClient.DTOs.Orderdetail;

namespace MyticAuraClient.DTOs.Order
{
    public class ReadOrderDto
    {
        public Guid OrderID { get; set; }
        public Guid UserID { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        public string RecipientName { get; set; } = string.Empty;
        public string RecipientPhone { get; set; } = string.Empty;
        public string RecipientAddress { get; set; } = string.Empty;

        public List<ReadOrderDetailDto> OrderDetails { get; set; } = new();
    }
}
