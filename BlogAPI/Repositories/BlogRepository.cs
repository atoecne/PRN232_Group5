using BlogAPI.Models;
using BlogAPI.Repositories.Interfaces;
using BlogService.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Repositories;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _context;

    public BlogRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<Blog> CreateAsync(Blog blog)
    {
        _context.Blogs.Add(blog);
        await _context.SaveChangesAsync();
        return blog;
    }

    public async Task DeleteAsync(Blog blog)
    {
        _context.Blogs.Remove(blog);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Blog>> GetAllAsync()
    {
        return await _context.Blogs
            .Include(b => b.Comments)
            .OrderByDescending(b => b.CreatedAt)
            .ToListAsync();
    }

    public async Task<Blog?> GetByIdAsync(int id)
    {
        return await _context.Blogs
            .Include(b => b.Comments)
            .FirstOrDefaultAsync(b => b.BlogId == id);
    }

    public async Task UpdateAsync(Blog blog)
    {
        _context.Entry(blog).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Blog>> SearchAsync(string keyword)
    {
        return await _context.Blogs
            .Where(b => b.BlogTitle.Contains(keyword) || b.BlogContent.Contains(keyword))
            .OrderByDescending(b => b.CreatedAt)
            .ToListAsync();
    }

}
