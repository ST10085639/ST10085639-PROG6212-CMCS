using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using ST10085639_PROG6212_CMCS.Controllers;
using ST10085639_PROG6212_CMCS.Data;
using ST10085639_PROG6212_CMCS.Models;
using System.Linq;


namespace ST10085639_PROG6212_CMCS.Controllers
{
    public class HRController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HRController(ApplicationDbContext db)
        {
            _db = db;
        }

        private bool IsHR()
        {
            var role = HttpContext.Session.GetString("Role");
            return role == "HR";
        }

        // This talks to the HRView.cshtml
        public IActionResult Index()
        {
            if (!IsHR()) return Unauthorized();

            var users = _db.Users.ToList();
            return View("HRView", users); // explicitly point to HRView.cshtml
        }

        // This adds the user
        // GET - place after the Index()
        public IActionResult AddUser()
        {
            if (!IsHR()) return Unauthorized();
            return View(); // will load AddUser.cshtml
        }

        // POST 
        [HttpPost]
        public IActionResult AddUser(User model)
        {
            if (!IsHR()) return Unauthorized();

            if (ModelState.IsValid)
            {
                _db.Users.Add(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // This Edits the users
        // GET 
        public IActionResult EditUser(int id)
        {
            if (!IsHR()) return Unauthorized();

            var user = _db.Users.FirstOrDefault(u => u.ID == id);
            if (user == null) return NotFound();

            return View(user); // This will load EditUser.cshtml
        }

        // POST 
        [HttpPost]
        public IActionResult EditUser(User model)
        {
            if (!IsHR()) return Unauthorized();

            if (ModelState.IsValid)
            {
                _db.Users.Update(model);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // This is the Invoice view
        public IActionResult Invoice(int id)
        {
            if (!IsHR()) return RedirectToAction("Login", "Authentication");

            var claim = _db.Claims.FirstOrDefault(c => c.ClaimID == id); // use _db

            if (claim == null) return NotFound();

            return View(claim); // Invoice.cshtml
        }

        // This downloads the invoice
        public IActionResult DownloadInvoice(int id)
        {
            var claim = _db.Claims.FirstOrDefault(c => c.ClaimID == id); // use _db

            if (claim == null) return NotFound();

            byte[] fileBytes = System.Text.Encoding.UTF8.GetBytes("Invoice placeholder");
            return File(fileBytes, "application/pdf", "Invoice.pdf");
        }

        // This approves the claims
        public IActionResult ApprovedClaims()
        {
            if (!IsHR()) return Unauthorized();

            var approvedClaims = _db.Claims
                .Where(c => c.Status == "Approved") // This makes sure Claim has Status
                .ToList();

            return View(approvedClaims); // ApprovedClaims.cshtml
        }
    }
}
