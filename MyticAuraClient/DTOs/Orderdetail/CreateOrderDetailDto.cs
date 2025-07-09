namespace MyticAuraClient.DTOs.Orderdetail
{
    public class CreateOrderDetailDto
    {
        public Guid ProductId { get; set; }
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
