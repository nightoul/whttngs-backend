namespace whttngs_backend.Models
{
    public class VideoView
    {
        public int VideoViewId { get; set; }
        public int PostId { get; set; }
        public string VisitorIP { get; set; } = string.Empty;
        public string VisitorLocation { get; set; } = string.Empty;
        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;
        public TimeSpan ViewStartPosition { get; set; } 
        public TimeSpan ViewEndPosition { get; set; }
    }
}
