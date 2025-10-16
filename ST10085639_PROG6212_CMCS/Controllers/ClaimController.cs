// Microsoft Learn. 2024. Model binding in ASP.NET Core MVC, 19 July 2025. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/model-binding [Accessed 16 October 2025].
// Microsoft Learn. 2024. File uploads in ASP.NET Core, 27 September 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads [Accessed 16 October 2025].
// Microsoft Learn. 2024. Entity Framework Core basics, 12 November 2024. [Online]. Available at: https://learn.microsoft.com/en-us/ef/core/ [Accessed 16 October 2025].
// Microsoft Learn. 2024. Authorization and role management in ASP.NET Core, 14 October 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/security/authorization/roles [Accessed 16 October 2025].
// TutorialsTeacher. 2024. ASP.NET Core MVC CRUD Operations, 2024. [Online]. Available at: https://www.tutorialsteacher.com/core/aspnet-core-crud [Accessed 16 October 2025].

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ST10085639_PROG6212_CMCS.Data;
using ST10085639_PROG6212_CMCS.Models;

namespace ST10085639_PROG6212_CMCS.Controllers
{

 // The creation, review, approve and reject of the lecturer claims are all controlled by the ClaimController
 // It also required a role-based access for the academic managers, program coordinators and lecturers
    public class ClaimController : Controller
    {
        // This is the dependency injection of the apps database context
        private readonly ApplicationDbContext _db;

        public ClaimController(ApplicationDbContext db)
        {
            _db = db;
        }

        // This displays all the submitted claims for the admin view (Programme Coordinator & Academic Manager)
        public IActionResult AdminView()
        {
            if (!IsAdmin())
                return Unauthorized();

            var claims = _db.Claims.ToList();
            return View(claims);
        }

        // This displays the claim creation form for lecturers
        [HttpGet]
        public IActionResult Create()
        {
            if (!IsLecturer())
                return Unauthorized();

            return View();
        }

        // This will handle the claim submissions from the lecturers
        // Also includes server-side validation and file upload functionality
        [HttpPost]
        public IActionResult Create(Claim model, IFormFile document)
        {
            if (!IsLecturer()) return Unauthorized();

            // To make sure a valid document is uploaded before processing
            if (document != null && document.Length > 0)
            {
                var extension = Path.GetExtension(document.FileName).ToLower();

                // ✅ Restrict file types
                var allowedExtensions = new[] { ".pdf", ".jpg", ".jpeg", ".docx" };
                if (!allowedExtensions.Contains(extension))
                {
                    ViewData["ErrorMessage"] = "Only PDF, JPG, and DOCX files are allowed.";
                    return View(model);
                }

                // It defines upload directory and will create it if its missing
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                // Provide each file with a different name to prevent naming issues
                var uniqueFileName = Guid.NewGuid().ToString() + extension; // prevent conflicts
                var filePath = Path.Combine(uploads, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    document.CopyTo(stream);
                }

                // ✅ Save both path & original name
                model.DocumentPath = "/uploads/" + uniqueFileName;
                model.DocumentName = document.FileName;
            }

            // This keeps the records of the claims in the database
            _db.Claims.Add(model);
            _db.SaveChanges();

            // This will take the lecturer to their claim history view
            return RedirectToAction("LecturerHistory");
        }

        // This will display a list of all the claims that the lecturer submitted
        public IActionResult LecturerHistory()
        {
            if (!IsLecturer())
                return Unauthorized();

            var claims = _db.Claims.ToList();
            return View(claims);
        }

        // ✅ Download function
        // It allows the users to download the claim-related documents
        public IActionResult DownloadDocument(string documentPath)
        {
            if (string.IsNullOrEmpty(documentPath))
                return NotFound();

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", documentPath.TrimStart('/'));
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            // ✅ Find claim to get the original DocumentName
            var claim = _db.Claims.FirstOrDefault(c => c.DocumentPath == documentPath);
            if (claim == null)
                return NotFound();

            // It determines the content type based on its file extension

            var contentType = "application/octet-stream"; // fallback
            var ext = Path.GetExtension(filePath).ToLower();

            if (ext == ".pdf")
                contentType = "application/pdf";
            else if (ext == ".jpg" || ext == ".jpeg")
                contentType = "image/jpeg";
            else if (ext == ".docx")
                contentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";

            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            // ✅ Use the original DocumentName instead of GUID
            var downloadName = string.IsNullOrEmpty(claim.DocumentName)
                                ? Path.GetFileName(filePath)
                                : claim.DocumentName;

            return File(fileBytes, contentType, downloadName);
        }

        // This will check if the current user has admin privileges
        private bool IsAdmin()
        {
            var role = HttpContext.Session.GetString("Role");
            return role == "Programme Coordinator" || role == "Academic Manager";
        }

        // This will check if the current user is a lecturer
        private bool IsLecturer()
        {
            var role = HttpContext.Session.GetString("Role");
            return role == "Lecturer";
        }

        // This will approve the submitted claims
        [HttpPost]
        public IActionResult Approve(int claimID)
        {
            if (!IsAdmin())
                return Unauthorized();

            var claim = _db.Claims.FirstOrDefault(c => c.ClaimID == claimID);
            if (claim != null)
            {
                claim.Status = "Approved";
                _db.Attach(claim);
                _db.Entry(claim).Property(c => c.Status).IsModified = true;
                _db.SaveChanges();
            }

            return RedirectToAction("AdminView");
        }

        // This will reject the submitted claim
        [HttpPost]
        public IActionResult Reject(int claimID)
        {
            if (!IsAdmin())
                return Unauthorized();

            var claim = _db.Claims.FirstOrDefault(c => c.ClaimID == claimID);
            if (claim != null)
            {
                claim.Status = "Rejected";
                _db.Attach(claim);
                _db.Entry(claim).Property(c => c.Status).IsModified = true;
                _db.SaveChanges();
            }

            return RedirectToAction("AdminView");
        }
    }
}
