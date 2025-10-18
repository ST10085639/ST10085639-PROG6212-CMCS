// Microsoft Learn. 2024. Unit testing controller logic in ASP.NET Core, 17 July 2024. [Online]. Available at: https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/testing [Accessed 18 October 2025].
// Microsoft Learn. 2022. In-memory database provider - EF Core, 23 November 2022. [Online]. Available at:https://learn.microsoft.com/en-us/ef/core/testing/in-memory [Accessed 18 October 2025].
// Sharma, M. 2023. Mastering Unit Testing in .NET 6: Build Reliable and Maintainable Applications with xUnit and MSTest. Packt Publishing, 2023. [Online]. Available at: https://www.packtpub.com/en-us/product/mastering-unit-testing-in-net-6-9781803241766 [Accessed 18 October 2025].


using System;
using System.Collections.Generic;
using System.Linq;
using ST10085639_PROG6212_CMCS.Models;
using ST10085639_PROG6212_CMCS.Data;
using ST10085639_PROG6212_CMCS.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;

namespace ST10085639_PROG6212_CMCS.Tests.Controllers
{
// This uses MSTest to define a test class for the AuthenticationController
    [TestClass]
    public class AuthenticationControllerTests
    {
        private ApplicationDbContext _db;
        private AuthenticationController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "ÄuthTestDb")
                .Options;

            _db = new ApplicationDbContext(options);
            _controller = new AuthenticationController(_db);
        }

        [TestMethod]
        public void SignUp_ValidUser_RedirectsToLogin()
        {
            // This creates a valid user instance
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@gmail.com",
                Password = "Password@1",
                ConfirmPassword = "Password@1",
                Role = "Lecturer"
            };

            // This calls the SignUp method
            var result = _controller.SignUp(user) as RedirectToActionResult;

            // This ensures the user(s) is redirected to the login page
            Assert.IsNotNull(result);
            Assert.AreEqual("Login", result.ActionName);
        }

        [TestMethod]
        public void SignUp_InvalidModel_ReturnsView()
        {
            // A error sent to the ModelState to show a input is ivalid
            _controller.ModelState.AddModelError("Email", "Required");
            var user = new User();

            // Attempting to sign up with invalid data
            var result = _controller.SignUp(user) as ViewResult;

            // To make sure the view is returned and the model data is preserved
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result.Model);
        }
    }
}
