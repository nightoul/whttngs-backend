namespace whttngs_backend.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public string VisitorIP { get; set; } = string.Empty;
        public string VisitorLocation { get; set; } = string.Empty;
        public DateTime VisitStartedAt { get; set; } = DateTime.UtcNow;
        public DateTime? VisitEndedAt { get; set; }
    }
}
