using AutoMapper;
using BlogAPI.DTOs;
using BlogAPI.Models;
using BlogAPI.Repositories.Interfaces;
using BlogAPI.Services.Interfaces;

namespace BlogAPI.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _repo;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<ReadCommentDto> CreateAsync(CreateCommentDto dto)
    {
        var comment = _mapper.Map<Comment>(dto);
        comment.CreatedAt = DateTime.Now;
        var result = await _repo.CreateAsync(comment);
        return _mapper.Map<ReadCommentDto>(result);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var comment = await _repo.GetByIdAsync(id);
        if (comment == null) return false;

        await _repo.DeleteAsync(comment);
        return true;
    }

    public async Task<bool> ModerateAsync(int commentId, bool isVisible)
    {
        var comment = await _repo.GetByIdAsync(commentId);
        if (comment == null) return false;

        comment.IsVisible = isVisible;
        await _repo.UpdateAsync(comment);
        return true;
    }
}
