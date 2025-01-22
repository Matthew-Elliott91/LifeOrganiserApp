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
        private readonly IWebHostEnvironment _webHost;

        public JobApplicationsController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            _context = context;
            _webHost = webHost;
        }

        public async Task<IActionResult> JobApplications(string sortOrder)
        {

            var jobApplications = await _context.JobApplicationsTrackers.ToListAsync();
            ViewData["CompanySortParam"] = String.IsNullOrEmpty(sortOrder) ? "company_desc" : "";
            ViewData["ClosingDateSortParam"] = sortOrder == "date_asc" ? "date_desc" : "date_asc";
            ViewData["StatusSortParam"] = String.IsNullOrEmpty(sortOrder) ? "status_desc" : "";

            //Sorting logic
            switch (sortOrder)
            {
                case "company_desc":
                    jobApplications = jobApplications.OrderByDescending(e => e.CompanyName).ToList();
                    break;
                case "status_desc":
                    jobApplications = jobApplications.OrderByDescending(e => e.Status).ToList();
                    break;
                case "date_asc":
                    jobApplications = jobApplications.OrderBy(e => e.ClosingDate).ToList();
                    break;
                default:
                    jobApplications = jobApplications.OrderBy(e => e.CompanyName).ToList();
                    break;

            } 

            return View(jobApplications);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobApplicationsTracker jobApplication, IFormFile? file)
        {
            if (file != null && file.Length > 0)
            {
                // Check if the file size exceeds 300KB
                if (file.Length > 600 * 1024)
                {
                    ModelState.AddModelError("JobSpecification", "File size exceeds the 600KB limit.");
                    return View(jobApplication);
                }

                string uploadsFolder = Path.Combine(_webHost.WebRootPath, "uploads/JobSpecifications");
                string fileName = Path.GetFileName(file.FileName);
                string fileSavePath = Path.Combine(uploadsFolder, fileName);

                using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Store the file path in the JobSpecification property
                jobApplication.JobSpecification = Path.Combine("uploads/JobSpecifications", fileName);
            }
            else
            {
                // Optionally, you can set a default value or leave it as null
                jobApplication.JobSpecification = null;
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(jobApplication);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(JobApplications));
                }
                catch (Exception ex)
                {
                    // Log the exception (you can use a logging framework here)
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                // Log the validation errors
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        Console.WriteLine($"Property: {state.Key}, Error: {error.ErrorMessage}");
                    }
                }
            }

            return View(jobApplication);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            JobApplicationsTracker jobApplication = _context.JobApplicationsTrackers.Find(id);
            if (jobApplication == null)
            {
                return RedirectToAction(nameof(JobApplications));
            }
            else
            {
                _context.JobApplicationsTrackers.Remove(jobApplication);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(JobApplications));
        }

        public IActionResult Edit(int id)
        {
            JobApplicationsTracker jobApplication = _context.JobApplicationsTrackers.Find(id);
            return View(jobApplication);
        }

        [HttpPost]
        public IActionResult Edit(JobApplicationsTracker jobApplication, IFormFile? file)
        {
            
            {
                if (file != null && file.Length > 0)
                {
                    string uploadsFolder = Path.Combine(_webHost.WebRootPath, "uploads/JobSpecifications");
                    string fileName = Path.GetFileName(file.FileName);
                    string fileSavePath = Path.Combine(uploadsFolder, fileName);

                    using (FileStream stream = new FileStream(fileSavePath, FileMode.Create))
                    {
                         file.CopyToAsync(stream);
                    }

                    // Store the file path in the JobSpecification property
                    jobApplication.JobSpecification = Path.Combine("uploads/JobSpecifications", fileName);
                }
                else
                {
                    // Optionally, you can set a default value or leave it as null
                    jobApplication.JobSpecification = null;
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(jobApplication);
                        _context.SaveChangesAsync();
                        return RedirectToAction(nameof(JobApplications));
                    }
                    catch (Exception ex)
                    {
                        // Log the exception (you can use a logging framework here)
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    // Log the validation errors
                    foreach (var state in ModelState)
                    {
                        foreach (var error in state.Value.Errors)
                        {
                            Console.WriteLine($"Property: {state.Key}, Error: {error.ErrorMessage}");
                        }
                    }
                }

                return View(jobApplication);
            }
        }


        public IActionResult Download(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                return NotFound();
            }

            var fullPath = Path.Combine(_webHost.WebRootPath, filePath);
            if (!System.IO.File.Exists(fullPath))
            {
                return NotFound();
            }

            var fileBytes = System.IO.File.ReadAllBytes(fullPath);
            var fileName = Path.GetFileName(fullPath);
            return File(fileBytes, "application/octet-stream", fileName);
        }








    }
}