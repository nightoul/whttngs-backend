
namespace whttngs_backend.Models
{
    public class Visit
    {
        public int VisitId { get; set; }
        public string VisitorIP { get; set; } = string.Empty;
        public string VisitorLocation { get; set; } = string.Empty;
        public DateTime VisitedAt { get; set; } = DateTime.UtcNow;
    }
}