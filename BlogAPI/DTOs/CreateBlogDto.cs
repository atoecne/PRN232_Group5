namespace BlogAPI.DTOs
{
    public class CreateBlogDto
    {
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public string BlogTitle { get; set; } = null!;
        public string BlogContent { get; set; } = null!;
        public string BlogImg { get; set; } = null!;
    }
}
