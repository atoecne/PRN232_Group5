namespace MyticAuraClient.DTOs.Orderdetail
{
    public class ReadOrderDetailDto
    {
        public Guid OrderDetailId { get; set; }
        public Guid ProductId { get; set; }
        public string Size { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal SubTotal => Quantity * Price;
    }
}
