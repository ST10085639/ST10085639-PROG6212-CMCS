// Mircosoft Learn. 2024. Authentication and authorization in ASP.NET Core, 14 February 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/ [Accessed 16 October 2025].
// Mircosoft Learn. 2024. Session and state management in ASP.NET Core, 24 April 2024. [Online]. Available at:https://learn.microsoft.com/en-us/aspnet/core/fundamentals/app-state [Accessed 16 October 2025].
// Mircosoft Learn. 2024. Model validation in ASP.NET Core MVC, 28 August 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation [Accessed 16 October 2025].
// Mircosoft Learn. 2024. Razor Pages and MVC views in ASP.NET Core, 17 July 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/views/overview [Accessed 16 October 2025].
// TutorialsTeacher. 2024. ASP.NET Core Authentication Tutorial, 2024. . [Online]. Available at: https://www.tutorialsteacher.com/core/aspnet-core-authentication [Accessed 16 October 2025].

using Microsoft.AspNetCore.Mvc;
using ST10085639_PROG6212_CMCS.Data;
using ST10085639_PROG6212_CMCS.Models;

namespace ST10085639_PROG6212_CMCS.Controllers
{
    // The fucntions of the user registration (SignUp), login and logout are controlled by the authentication controller.
    // It handles sessions, verifies credentials and redirects accoring to the user roles.
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
                    case "HR":
                        return RedirectToAction("HRView", "HR"); // HRView page
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
