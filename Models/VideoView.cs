namespace whttngs_backend.Models
{
    public class VideoView
    {
        public int VideoViewId { get; set; }
        public int VideoId { get; set; }
        public string VisitorIP { get; set; } = string.Empty;
        public string VisitorLocation { get; set; } = string.Empty;
        public TimeSpan WatchDuration { get; set; }
        public DateTime ViewedAt { get; set; } = DateTime.UtcNow;

    }
}
