using BlogAPI.DTOs;

namespace BlogAPI.Services.Interfaces;

public interface ICommentService
{
    Task<ReadCommentDto> CreateAsync(CreateCommentDto dto);
    Task<bool> DeleteAsync(int id);

    Task<bool> ModerateAsync(int commentId, bool isVisible);
}
