// Microsoft. 2024. Data annotations in ASP.NET Core MVC, 28 August 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-9.0 [Accessed 16 October 2025].
// Microsoft. 2024. Regular expressions in .NET, 18 July 2024. [Online]. Available at:https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference [Accessed 16 October 2025].
// TutorialsTeacher. 2024. ASP.NET Core MVC Model Validation, 2024. [Online]. Available at:https://www.tutorialsteacher.com/core/aspnet-core-model-validation [Accessed 16 October 2025].
// Microsoft. 2024. Identity and security in ASP.NET Core, 13 July 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity [Accessed 16 October 2025].

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ST10085639_PROG6212_CMCS.Models
{
    // It defines the structure and validation for every user in the CMCS system
    // It includes basic identity info, login credentials and role-based access details
    public class User
    {
        public int ID {  get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        // The password must meet ceratin rules such as 8 characters long, one uppercase, one lowercase, one number and a special character
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain 1 uppercase letter, 1 lowercase letter, 1 special character (@#$), and 1 number.")]
        public string? Password { get; set; } //Reference must still be added from my notepad

        // This confirms that the password entered matches the first password fiels
        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; } // This is password validation for security purposes

        [Required]
        public string? Role { get; set; }
    }
}
