namespace whttngs_backend.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? VideoId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
