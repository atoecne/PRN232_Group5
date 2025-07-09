using MyticAuraClient.DTOs.Cart;
using MyticAuraClient.Service.Interface;

namespace MyticAuraClient.Service
{
    public class CartService : ICartService
    {
        private readonly HttpClient _client;

        public CartService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("GatewayClient");
        }

        private readonly Guid _userId = Guid.Parse("11111111-1111-1111-1111-111111111111");

        public async Task<List<ReadCartDto>> GetUserCartAsync()
        {
            var response = await _client.GetAsync($"/carts/user/{_userId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ReadCartDto>>() ?? new();
        }

        public async Task AddToCartAsync(CreateCartDto dto)
        {
            await _client.PostAsJsonAsync("/carts", dto);
        }

        public async Task DeleteCartItemAsync(Guid cartId)
        {
            var res = await _client.DeleteAsync($"/carts/{cartId}");
            res.EnsureSuccessStatusCode();
        }
        public async Task UpdateCartAsync(Guid cartId, UpdateCartDto dto)
        {
            var response = await _client.PutAsJsonAsync($"/carts/{cartId}", dto);
            response.EnsureSuccessStatusCode();
        }

        public async Task ClearCartAsync()
        {
            var response = await _client.DeleteAsync($"/carts/user/{_userId}");
            response.EnsureSuccessStatusCode();
        }

    }
}
