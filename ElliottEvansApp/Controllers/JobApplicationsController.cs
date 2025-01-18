using ElliottEvansApp.Data;
using ElliottEvansApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ElliottEvansApp.Controllers
{
    public class JobApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JobApplicationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var jobApplications = await _context.JobApplicationsTrackers.ToListAsync();
            return View(jobApplications);
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobApplicationsTracker jobApplication)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobApplication);
                await _context.SaveChangesAsync();
                return PartialView("_JobApplicationRow", jobApplication);
            }
            return BadRequest();
        }
    }
}