using BlogAPI.Models;

namespace BlogAPI.Repositories.Interfaces;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetAllAsync();
    Task<Blog?> GetByIdAsync(int id);
    Task<Blog> CreateAsync(Blog blog);

    Task UpdateAsync(Blog blog);

    Task DeleteAsync(Blog blog);

    Task<IEnumerable<Blog>> SearchAsync(string keyword);

}
