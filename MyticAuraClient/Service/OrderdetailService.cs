using MyticAuraClient.DTOs.Orderdetail;
using MyticAuraClient.Service.Interface;

namespace MyticAuraClient.Service
{
    public class OrderdetailService : IOrderdetailService
    {
        private readonly HttpClient _client;

        public OrderdetailService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("GatewayClient");
        }

        public async Task<List<ReadOrderDetailDto>> GetByOrderIdAsync(Guid orderId)
        {
            var response = await _client.GetAsync($"/orderdetails/order/{orderId}");
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<ReadOrderDetailDto>>() ?? new();
        }
    }
}