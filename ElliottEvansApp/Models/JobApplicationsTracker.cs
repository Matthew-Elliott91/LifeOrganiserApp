using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace ElliottEvansApp.Models
{
    public class JobApplicationsTracker
    {
        public int Id { get; set; }
        [StringLength(40, ErrorMessage = "Company name can have a maximum of 40 characters")]
        [Required] public string CompanyName { get; set; }
        [StringLength(40, ErrorMessage = "Position can have a maximum of 40 characters")]
        [Required] public string Position { get; set; }
        [StringLength(40, ErrorMessage = "Location can have a maximum of 40 characters")]
        [Required] public string Location { get; set; }

        [Required] public DateTime DateApplied { get; set; }

        [Required] public DateTime ClosingDate { get; set; }
        [StringLength(40, ErrorMessage = "Application can have a maximum of 40 characters")]
        [Required] public string ApplicationPlatform { get; set; }
        
        [Required] public string Status { get; set; }
        [StringLength(200, ErrorMessage = "Application URL can have a maximum of 200 characters")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? ApplicationURL { get; set; }

        public string? JobSpecification { get; set; }

        public string? Notes { get; set; }


    }
}