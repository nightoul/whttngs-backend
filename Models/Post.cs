using System;
using System.Collections.Generic;
using whttngs_backend.Models;

namespace whttngs_backend.Models
{
    public enum PostType
    {
        Text,
        Video,
        TextAndVideo
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; } = "sometitle";
        public string Content { get; set; } = "somecontent";
        public string? VideoUrl { get; set; } // Nullable for posts that don’t have a video
        public PostType PostType { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation property for related Visits
        public ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
