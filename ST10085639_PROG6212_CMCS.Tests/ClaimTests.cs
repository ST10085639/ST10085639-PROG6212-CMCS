// MSDN. 2025. Unit testing in .NET with MSTest, 27 March 2025. [Online]. Available at: https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest [Accessed 18 October 2025].

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ST10085639_PROG6212_CMCS.Models;
using System;

namespace ST10085639_PROG6212_CMCS.Tests.Models
{
    [TestClass]
    public class ClaimTests
    {
        [TestMethod]
        public void CalculateTotal_ShouldReturnCorrectAmount() 
        {
            // This is setting up the test data before execution
            var claim = new Claim
            {
                HoursWorked = 10,
                HourlyRate = 150
            };

            // This executes the method thats being tested
            var result = claim.CalculateTotal();

            // This verifies that the output matches the expected value
            Assert.AreEqual(1500, result);
        }
    }
}
