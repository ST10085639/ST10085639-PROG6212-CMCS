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

            _db.Claims.Add(model);
            _db.SaveChanges();

            return RedirectToAction("LecturerHistory");
        }

        public IActionResult LecturerHistory()
        {

        }

        public IActionResult DownloadDocument(string documentPath)
        {

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

        }

        [HttpPost]
        public IActionResult Reject(int claimID)
        {
            
        }
    }
}
