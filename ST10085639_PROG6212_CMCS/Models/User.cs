//References:

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ST10085639_PROG6212_CMCS.Models
{
    public class User
    {
        public int ID {  get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@#$]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters long and contain 1 uppercase letter, 1 lowercase letter, 1 special character (@#$), and 1 number.")]
        public string? Password { get; set; } //Reference must still be added from my notepad

        [Required]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; } //Reference must still be added from my notepad

        [Required]
        public string? Role { get; set; }
    }
}
