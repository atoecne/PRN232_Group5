using ChatAPI.DTOs;
using ChatAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChatAPI.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        private readonly List<string> _sampleQuestions = new()
    {
        "Làm sao để đặt hàng?",
        "Chính sách đổi trả như thế nào?",
        "Có hỗ trợ thanh toán khi nhận hàng không?",
        "Tôi muốn liên hệ hỗ trợ?",
        "Cửa hàng có khuyến mãi gì không?"
    };

        [HttpGet("sample")]
        public IActionResult SampleQuestions()
        {
            return Ok(_sampleQuestions);
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] ChatRequestDto request)
        {
            var response = await _chatService.SendAsync(request);
            return Ok(response);
        }
    }
}
