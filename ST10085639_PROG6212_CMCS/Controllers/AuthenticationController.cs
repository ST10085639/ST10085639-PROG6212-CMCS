using Microsoft.AspNetCore.Mvc;
using ST10085639_PROG6212_CMCS.Data;

namespace ST10085639_PROG6212_CMCS.Controllers
{
    public class AuthenticationController : Controller
    {
        public readonly ApplicationDbContext _db;

        public AuthenticationController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult SignUp() => View();

        [HttpPost]
        public IActionResult SignUp(User model)
        {
            
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {

        }

        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Authentication");
        }
    }
}
