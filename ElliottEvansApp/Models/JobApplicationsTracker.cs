namespace ElliottEvansApp.Models
{
    public class JobApplicationsTracker
    {
        public required int Id { get; set; }
        public required string CompanyName { get; set; }
        public required string Position { get; set; }
        public required string Location { get; set; }
        public required DateTime DateApplied { get; set; } 
        public required DateTime ClosingDate { get; set; }
        public required string ApplicationPlatform { get; set; }
        public required string Status { get; set; }
        public string JobSpecification { get; set; }
        public required string Notes { get; set; }

    }
}
