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
        // This is the dependency injection of the databse context and it accessed the users table
        private readonly ApplicationDbContext _db;

        public AuthenticationController(ApplicationDbContext db)
        {
            _db = db;
        }

        // It displays the users registration form
        [HttpGet]
        public IActionResult SignUp() => View();

        // This handles the submissions for the registration form
        [HttpPost]
        public IActionResult SignUp(User model)
        {
            // This identifies whether the imput model matches the validation rules specified in the user model
            if (!ModelState.IsValid) return View(model);

            // This will add the new user record to the database
            _db.Users.Add(model);
            _db.SaveChanges();

            // This will redirect the users to the login page once registration is complete
            return RedirectToAction("Login");
        }

        //This displays the login form for the user authentication
        [HttpGet]
        public IActionResult Login() => View();

        // This handles the login form submissions and confirms user credentials, after the authentication is successful, it creates a session
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // This will check if the email and password matches an existing user
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

            // This displays an error if the authentication fails
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        // This will logout the current user by clearing the active session
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // This removes all the session data to ensure a clean logout
            return RedirectToAction("Login", "Authentication"); // This redirects the users to the login page after logging out
        }
    }
}
