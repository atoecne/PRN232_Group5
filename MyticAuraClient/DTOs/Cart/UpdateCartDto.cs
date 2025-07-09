namespace MyticAuraClient.DTOs.Cart
{
    public class UpdateCartDto
    {
        public int Quantity { get; set; }
        public string Size { get; set; } = string.Empty;
    }
}
