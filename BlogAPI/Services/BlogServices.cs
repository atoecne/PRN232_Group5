using AutoMapper;
using BlogAPI.DTOs;
using BlogAPI.Models;
using BlogAPI.Repositories.Interfaces;
using BlogAPI.Services.Interfaces;
using System.Reflection.Metadata;


namespace BlogAPI.Services;

public class BlogServices : IBlogService
{
    private readonly IBlogRepository _repo;
    private readonly IMapper _mapper;

    public BlogServices(IBlogRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ReadBlogDto> CreateAsync(CreateBlogDto dto)
    {
        var blog = _mapper.Map<Blog>(dto);
        blog.CreatedAt = DateTime.Now;
        var result = await _repo.CreateAsync(blog);
        return _mapper.Map<ReadBlogDto>(result);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var blog = await _repo.GetByIdAsync(id);
        if (blog == null) return false;
        await _repo.DeleteAsync(blog);
        return true;
    }

    public async Task<IEnumerable<ReadBlogDto>> GetAllAsync()
    {
        var blogs = await _repo.GetAllAsync();
        foreach (var blog in blogs)
        {
            blog.Comments = blog.Comments?.Where(c => c.IsVisible).ToList() ?? new List<Comment>();
        }
        return _mapper.Map<IEnumerable<ReadBlogDto>>(blogs);
    }

    public async Task<ReadBlogDto?> GetByIdAsync(int id)
    {
        var blog = await _repo.GetByIdAsync(id);
        if (blog == null) return null;

        blog.Comments = blog.Comments?.Where(c => c.IsVisible).ToList() ?? new List<Comment>();

        return _mapper.Map<ReadBlogDto>(blog);
    }

    public async Task<bool> UpdateAsync(int id, UpdateBlogDto dto)
    {
        var blog = await _repo.GetByIdAsync(id);
        if (blog == null) return false;
        _mapper.Map(dto, blog);
        await _repo.UpdateAsync(blog);
        return true;
    }

    public async Task<IEnumerable<ReadBlogDto>> SearchAsync(string keyword)
    {
        var blogs = await _repo.SearchAsync(keyword);
        return _mapper.Map<IEnumerable<ReadBlogDto>>(blogs);
    }

}
