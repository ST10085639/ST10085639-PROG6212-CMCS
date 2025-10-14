//References:

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;

namespace ST10085639_PROG6212_CMCS.Models
{
    public class Claim
    {
        public int ClaimID { get; set; }

        [Required]
        public string? LecturerName { get; set; }

        [Required]
        public DateTime SubmittedDate { get; set; } = DateTime.Now; //Reference must still be added from my notepad

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public int HoursWorked { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)] //Reference must still be added from my notepad
        public decimal HourlyRate { get; set; }

        public string? DocumentPath { get; set; }

        public string? DocumentName { get; set; }

        public string? Status { get; set; } = "Pending";

        public decimal CalculateTotal() //Reference must still be added from my notepad
        {
            return HoursWorked * HourlyRate;
        }

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TotalAmount => CalculateTotal();
    }
}
