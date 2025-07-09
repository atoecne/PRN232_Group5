using System.ComponentModel.DataAnnotations;

namespace MyticAuraClient.DTOs.Order
{
    public class UpdateOrderStatusDto
    {
        public Guid OrderId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Status { get; set; } = string.Empty;
    }
}
