using MyticAuraClient.DTOs.Order;
using MyticAuraClient.DTOs.Orderdetail;
using MyticAuraClient.Service.Interface;
using Newtonsoft.Json;

namespace MyticAuraClient.Service
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _client;
        public OrderService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("GatewayClient");
        }
        private readonly Guid _userId = Guid.Parse("11111111-1111-1111-1111-111111111111");
        public async Task<List<ReadOrderDto>> GetOrdersByUserAsync(Guid userId)
        {
            var response = await _client.GetAsync($"/orders/user/{userId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ReadOrderDto>>(content)!;
        }

        public async Task<ReadOrderDto> CreateOrderAsync(CreateOrderDto dto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(dto), System.Text.Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/orders", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReadOrderDto>(result)!;
        }

        public async Task<List<ReadOrderDetailDto>> GetOrderDetailsAsync(Guid orderId)
        {
            var response = await _client.GetAsync($"/orders/{orderId}/details");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<ReadOrderDetailDto>>(content)!;
        }

        public async Task ConfirmOrderAsync(Guid orderId)
        {
            var response = await _client.PutAsync($"/orders/{orderId}/confirm", null);
            response.EnsureSuccessStatusCode();
        }

        public async Task CancelOrderAsync(Guid orderId)
        {
            var response = await _client.PutAsync($"/orders/{orderId}/cancel", null);
            response.EnsureSuccessStatusCode();
        }

        Task<List<ReadOrderDetailDto>> IOrderService.GetOrderDetailsAsync(Guid orderId)
        {
            throw new NotImplementedException();
        }
    }
}