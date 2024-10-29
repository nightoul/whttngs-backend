namespace whttngs_backend.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public int PostId { get; set; }
        public string VimeoUrl { get; set; } = string.Empty;
    }
}
