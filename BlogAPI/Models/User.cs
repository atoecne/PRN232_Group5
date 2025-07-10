using System.ComponentModel.DataAnnotations;

namespace BlogAPI.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string UserName { get; set; }

        public ICollection<Blog>? Blogs { get; set; }
    }
}
