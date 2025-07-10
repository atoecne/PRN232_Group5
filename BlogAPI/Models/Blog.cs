using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class Blog
    {
        public int BlogId { get; set; }

        [Required(ErrorMessage = "User is required")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(255, ErrorMessage = "Title cannot be longer than 255 characters")]
        public string BlogTitle { get; set; } = null!;

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string BlogContent { get; set; } = null!;

        [Required(ErrorMessage = "Image is required")]
        public string? BlogImg { get; set; } = null;

        [Required(ErrorMessage = "Created date is required")]
        public DateTime CreatedAt { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();

    }
}
