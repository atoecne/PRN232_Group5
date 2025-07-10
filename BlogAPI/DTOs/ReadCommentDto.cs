namespace BlogAPI.DTOs;

public class ReadCommentDto
{
    public int CommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
