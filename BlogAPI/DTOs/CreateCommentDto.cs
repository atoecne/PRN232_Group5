namespace BlogAPI.DTOs;

public class CreateCommentDto
{
    public string Content { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public int BlogId { get; set; }
}
