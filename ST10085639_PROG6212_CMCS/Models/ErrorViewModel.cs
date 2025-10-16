// Microsoft. 2024. Handle errors in ASP.NET Core, 25 September 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/error-handling [Accessed 16 October 2025 ].
// Microsft. 2024. Logging and diagnostics in ASP.NET Core, 18 September 2024. [Online]. Available at:https://learn.microsoft.com/en-us/aspnet/core/fundamentals/logging [Accessed 16 October 2025 ].
// TutorialsTeacher. 2024. ASP.NET Core MVC Error Handling, 2024. [Online]. Available at:https://www.tutorialsteacher.com/core/aspnet-core-error-handling [Accessed 16 October 2025 ].

namespace ST10085639_PROG6212_CMCS.Models
{
    // This class provides details for displaying error information in the UI
    // It assist showing user-friendly error messages and offers help debugging issues when they occur
    public class ErrorViewModel
    {
        // This is a unique identifier for the current request, helpful for tracing and diagnostics
        public string? RequestId { get; set; }

        // This shows whether the RequestID should be displayed in the error view
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId); // It helps determine if the RequestID is valid
    }
}
