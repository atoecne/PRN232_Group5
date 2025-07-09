using MyticAuraClient.DTOs.Cart;

namespace MyticAuraClient.Service.Interface
{
    public interface ICartService
    {
        Task<List<ReadCartDto>> GetUserCartAsync();
        Task AddToCartAsync(CreateCartDto dto);
        Task DeleteCartItemAsync(Guid cartId);
        Task UpdateCartAsync(Guid cartId, UpdateCartDto dto);
        Task ClearCartAsync();
    }
}
