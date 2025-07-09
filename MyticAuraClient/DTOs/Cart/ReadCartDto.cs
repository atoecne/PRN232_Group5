namespace MyticAuraClient.DTOs.Cart
{
    public class ReadCartDto
    {
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductImg { get; set; }
        public string Size { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal TotalPrice => UnitPrice * Quantity;
    }
}
