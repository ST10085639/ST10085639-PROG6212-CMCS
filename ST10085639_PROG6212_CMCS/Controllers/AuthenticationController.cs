//References:

using Microsoft.AspNetCore.Mvc;
using ST10085639_PROG6212_CMCS.Data;
using ST10085639_PROG6212_CMCS.Models;

namespace ST10085639_PROG6212_CMCS.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthenticationController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult SignUp() => View();

        [HttpPost]
        public IActionResult SignUp(User model)
        {
            if (!ModelState.IsValid) return View(model);

            _db.Users.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                // Convert Guid to string when storing in session
                HttpContext.Session.SetString("UserId", user.ID.ToString());
                HttpContext.Session.SetString("Role", user.Role ?? "");
                // Role-based redirection
                switch (user.Role)
                {
                    case "Lecturer":
                        return RedirectToAction("Create", "Claim"); // Submit Claims page
                    case "Programme Coordinator":
                    case "Academic Manager":
                        return RedirectToAction("AdminView", "Claim"); // AdminView page
                    default:
                        return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Authentication");
        }
    }
}
