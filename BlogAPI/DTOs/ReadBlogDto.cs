namespace BlogAPI.DTOs
{
    public class ReadBlogDto
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; } = null!;
        public string BlogContent { get; set; } = null!;
        public string BlogImg { get; set; } = null!;
        public int CategoryId { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<ReadCommentDto> Comments { get; set; } = new(); 
    }
}
