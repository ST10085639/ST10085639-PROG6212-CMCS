// Microsoft Learn. 2024. Handle requests with controllers in ASP.NET Core MVC, 17 June 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/actions?view=aspnetcore-9.0 [Accessed 16 October 2025].
// Mircosoft Learn. 2024. Error handling in ASP.NET Core, 25 September 2025. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-9.0 [Accessed 16 October 2025].
// Microsoft Learn. 2024. Dependency injection in ASP.NET Core, 18 September 2024.[Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-9.0 [Accessed 16 October 2025].
// Microsoft Learn. 2024. Routing in ASP.NET Core, 18 September 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-9.0 [Accessed 16 October 2025].
// TutorialTeaching. 2024. ASP.NET Core MVC Tutorial, 2024. [Online]. Available at: https://www.tutorialsteacher.com/core/aspnet-core-mvc [Accessed 16 October 2025].

using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ST10085639_PROG6212_CMCS.Models;

namespace ST10085639_PROG6212_CMCS.Controllers
{
    // The apps basic navigation requests are handled by the Home controller
    // it is in charge of bringing back views like error pages, privacy policy and the home page
    public class HomeController : Controller
    {

     // This allows the program to capture important runtime events or errors
        private readonly ILogger<HomeController> _logger;


     // A logger instance is created in the controller through the constructor
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Dsiplays the home page of the system
        public IActionResult Index()
        {
            return View();
        }

        // Displays the privacy policy page
        public IActionResult Privacy()
        {
            return View();
        }

        // This handles all the system errors and showss a detailed error page
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
         // Holds information about the current request or trace identifier
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
