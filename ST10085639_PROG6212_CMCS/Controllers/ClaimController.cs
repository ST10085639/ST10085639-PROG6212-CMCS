//Reference:

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ST10085639_PROG6212_CMCS.Data;
using ST10085639_PROG6212_CMCS.Models;

namespace ST10085639_PROG6212_CMCS.Controllers
{
    public class ClaimController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ClaimController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult AdminView()
        {
            if (!IsAdmin())
                return Unauthorized();

            var claims = _db.Claims.ToList();
            return View(claims);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (!IsLecturer())
                return Unauthorized();

            return View();
        }

        [HttpPost]
        public IActionResult Create(Claim model, IFormFile document)
        {
            if (!IsLecturer()) return Unauthorized();

            if (document != null && document.Length > 0)
            {
                var extension = Path.GetExtension(document.FileName).ToLower();

                //File Restriction Types
                var allowedExtentions = new[] { ".pdf", ".jpg", ".jpeg", ".docx" };
                if (!allowedExtentions.Contains(extension))
                {
                    ViewData["ErrorMessage"] = "Only PDF, JPG, JPEG, and DOCX files are allowed.";
                    return View(model);
                }

                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");
                if (Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                var uniqueFileName = Guid.NewGuid().ToString() + extension;
                var filePath = Path.Combine(uploads, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    document.CopyTo(stream);
                }

                //Save file name and path.
                model.DocumentPath = "/uploads/" + uniqueFileName;
                model.DocumentName = document.FileName;
            }

            _db.Claims.Add(model);
            _db.SaveChanges();

            return RedirectToAction("LecturerHistory");
        }

        public IActionResult LecturerHistory()
        {
            if (IsLecturer()) 
                return Unauthorized();

            var claims = _db.Claims.ToList();
            return View(claims);
        }

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

        private bool IsAdmin()
        {
            var role = HttpContext.Session.GetString("Role");
            return role == "Programme Coodinator" || role == "Academic Manager";
        }

        private bool IsLecturer()
        {
            var role = HttpContext.Session.GetString("Role");
            return role == "Lecturer";
        }

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
