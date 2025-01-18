using ElliottEvansApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ElliottEvansApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
       
        public DbSet<JobApplicationsTracker> JobApplicationsTrackers { get; set; }
    }

}
