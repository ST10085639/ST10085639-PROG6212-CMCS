// Microsoft Learn. 2024. Data annotations in ASP.NET CORE MVC, 28 August 2025. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/models/validation [Accessed 16 October 2025].
// Microsoft Learn. 2024. Working with DateTime in C#, 2024. [Online]. Available at:https://learn.microsoft.com/en-us/dotnet/api/system.datetime [Accessed 16 October 2025].
// Microsoft Learn. 2024. C# properties and methods, 14 November 2024. [Online]. Available at:https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties [Accessed 16 October 2025].


using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;

namespace ST10085639_PROG6212_CMCS.Models
{
    // The claims class reprrsents a lecturers claim in the CMCS system
    // The properties include dates, hours worked, hourly rate, document uploads and status
    public class Claim
    {
        public int ClaimID { get; set; }

        [Required]
        public string? LecturerName { get; set; }

        [Required]
        public DateTime SubmittedDate { get; set; } = DateTime.Now; 

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int HoursWorked { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)] 
        public decimal HourlyRate { get; set; }

        public string? DocumentPath { get; set; }

        public string? DocumentName { get; set; }

        public string? Status { get; set; } = "Pending";

        // It calculates the total amount of claim based on hours and hourly rate
        public decimal CalculateTotal() 
        {
            return HoursWorked * HourlyRate;
        }

        // The TotalAmount property will retun the calculated total and formatted as currency
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TotalAmount => CalculateTotal();
    }
}
