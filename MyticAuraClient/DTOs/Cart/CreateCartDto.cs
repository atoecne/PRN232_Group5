namespace MyticAuraClient.DTOs.Cart
{
    public class CreateCartDto
    {
        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
    }
}
