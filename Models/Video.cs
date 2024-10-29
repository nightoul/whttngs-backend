namespace whttngs_backend.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string VimeoUrl { get; set; } = string.Empty;
        public string ThumbnailUrl { get; set; } = string.Empty;
    }
}
