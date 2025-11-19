using Microsoft.AspNetCore.Mvc;
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

        // This is to view all the users
        public IActionResult Index()
        {
            if (!IsHR()) return Unauthorized();

            var users = _db.Users.ToList();
            return View(users);
        }

        // This is to add the user - GET
        public IActionResult AddUser()
        {
            if (!IsHR()) return Unauthorized();
            return View();
        }

        // This is to add the user - POST
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

        // This is to Edit the user - GET
        public IActionResult EditUser(int id)
        {
            if (!IsHR()) return Unauthorized();

            var user = _db.Users.FirstOrDefault(u => u.ID == id);
            if (user == null) return NotFound();

            return View(user);
        }

        // This is to Edit the user - POST
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

        public IActionResult Invoice(int id)
        {
            if (!IsHR())
                return RedirectToAction("Login", "Authentication");

            var claim = _context.Claims.FirstOrDefault(c => c.ClaimID == id);

            if (claim == null)
                return NotFound();

            return View(claim);
        }
    }
}
