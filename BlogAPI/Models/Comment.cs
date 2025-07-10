namespace BlogAPI.Models;

public class Comment
{
    public int CommentId { get; set; }
    public string Content { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsVisible { get; set; } = true;
    // FK
    public int BlogId { get; set; }
    public Blog Blog { get; set; } = null!;

}
