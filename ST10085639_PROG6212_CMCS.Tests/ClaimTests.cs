//Refernces:

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
            //Arrange
            var claim = new Claim
            {
                HoursWorked = 10,
                HourlyRate = 150
            };

            //Action
            var result = claim.CalculateTotal();

            //Assert
            Assert.AreEqual(1500, result);
        }
    }
}
