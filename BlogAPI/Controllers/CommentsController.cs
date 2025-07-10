using BlogAPI.DTOs;
using BlogAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly ICommentService _service;

    public CommentsController(ICommentService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<ReadCommentDto>> Create(CreateCommentDto dto)
    {
        var result = await _service.CreateAsync(dto);
        return Ok(result);
    }
    [HttpDelete("{id}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _service.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }

    [HttpPatch("{id}/moderate")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Moderate(int id, [FromBody] ModerateCommentDto dto)
    {
        var success = await _service.ModerateAsync(id, dto.IsVisible);
        return success ? NoContent() : NotFound();
    }
}
