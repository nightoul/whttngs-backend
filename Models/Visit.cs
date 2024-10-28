using System;

namespace whttngs_backend.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public int PostId { get; set; } // Foreign key to Posts table
        public string VisitorIP { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public DateTime VisitedAt { get; set; } = DateTime.UtcNow;

        // Navigation property back to the Post
        public Post Post { get; set; } = null!;
    }
}
