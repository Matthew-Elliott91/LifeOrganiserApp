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

        public async Task<IActionResult> JobApplications()
        {

            var jobApplications = _context.JobApplicationsTrackers.ToList();
           
            return View();
        }
    }


}