using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using ST10085639_PROG6212_CMCS.Controllers;
using ST10085639_PROG6212_CMCS.Data;
using ST10085639_PROG6212_CMCS.Models;


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

        public IActionResult HRView()
        {
            if (IsHR()) return Unauthorized();
            {
                var users = _db.Users.ToList();
                return View(users);
            }

            [HttpGet]

            public IActionResult AddUser()
            {
                if (!IsHR()) return Unauthorized();
                return View();
            }

            [HttpPost]
            public IActionResult AddUser(User model)
            {
                if (!IsHR()) return Unauthorized();

                _db.Users.Add(model);
                _db.SaveChanges();

                return RedirectToAction("HRView");
            }

            [HttpGet]
            public IActionResult EditUser(int id)
            {
                if (!IsHR()) return Unauthorized();

                var user = _db.Users.FirstOrDefault(u => u.UserID == id);
                return View(user);
            }

            [HttpPost]
            public IActionResult EditUser(User model)
            {
                if (!IsHR()) return Unauthorized();

                _db.Users.Update(model);
                _db.SaveChanges();

                return RedirectToAction("HRView");
            }
        }
    }
}



        
