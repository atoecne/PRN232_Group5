using BlogAPI.DTOs;

namespace BlogAPI.Services.Interfaces;

public interface IBlogService
{
    Task<IEnumerable<ReadBlogDto>> GetAllAsync();
    Task<ReadBlogDto?> GetByIdAsync(int id);
    Task<ReadBlogDto> CreateAsync(CreateBlogDto dto);
    Task<bool> UpdateAsync(int id, UpdateBlogDto dto);
    Task<bool> DeleteAsync(int id);

    Task<IEnumerable<ReadBlogDto>> SearchAsync(string keyword);

}
