using ChatAPI.DTOs;

namespace ChatAPI.Services.Interfaces
{
    public interface IChatService
    {
        Task<ChatResponseDto> SendAsync(ChatRequestDto request);
    }
}
