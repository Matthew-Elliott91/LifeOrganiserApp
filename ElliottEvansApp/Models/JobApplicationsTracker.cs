using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ElliottEvansApp.Models
{
    public class JobApplicationsTracker
    {
        public int Id { get; set; }

        [Required] public string CompanyName { get; set; }

        [Required] public string Position { get; set; }

        [Required] public string Location { get; set; }

        [Required] public DateTime DateApplied { get; set; }

        [Required] public DateTime ClosingDate { get; set; }

        [Required] public string ApplicationPlatform { get; set; }

        [Required] public string Status { get; set; }

        public string? ApplicationURL { get; set; }

        public string? JobSpecification { get; set; }

        public string? Notes { get; set; }


    }
}