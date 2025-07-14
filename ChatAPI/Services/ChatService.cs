using ChatAPI.DTOs;
using ChatAPI.Services.Interfaces;

namespace ChatAPI.Services
{
    public class ChatService : IChatService
    {
        private readonly Dictionary<string, string> _predefinedAnswers = new()
        {
            { "Làm sao để đặt hàng?", "Bạn có thể đặt hàng bằng cách thêm sản phẩm vào giỏ và chọn 'Thanh toán'." },
            { "Chính sách đổi trả như thế nào?", "Bạn có thể đổi trả trong vòng 7 ngày kể từ ngày nhận hàng." },
            { "Có hỗ trợ thanh toán khi nhận hàng không?", "Chúng tôi hỗ trợ thanh toán khi nhận hàng (COD)." },
            { "Tôi muốn liên hệ hỗ trợ?", "Bạn có thể gọi số hotline 1900-1234 hoặc nhắn qua Fanpage." },
            { "Cửa hàng có khuyến mãi gì không?", "Hiện tại chúng tôi đang có giảm giá 20% toàn bộ sản phẩm!" }
        };

        public async Task<ChatResponseDto> SendAsync(ChatRequestDto request)
        {
            string answer;

            if (string.IsNullOrWhiteSpace(request.Question))
            {
                answer = "❗ Vui lòng nhập câu hỏi.";
            }
            else if (_predefinedAnswers.TryGetValue(request.Question.Trim(), out var matchedAnswer))
            {
                answer = matchedAnswer;
            }
            else
            {
                answer = "🤖 Xin lỗi, tôi chưa có câu trả lời cho câu hỏi này.";
            }

            return await Task.FromResult(new ChatResponseDto { Answer = answer });
        }
    }
}
