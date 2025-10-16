//References:

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
            //Arrange
            var user = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john@gmail.com",
                Password = "Password@1",
                ConfirmPassword = "Password@1",
                Role = "Lecturer"
            };

            //Action
            var result = _controller.SignUp(user) as RedirectToActionResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Login", result.ActionName);
        }

        [TestMethod]
        public void SignUp_InvalidModel_ReturnsView()
        {
            //Arrange
            _controller.ModelState.AddModelError("Email", "Required");
            var user = new User();

            //Action
            var result = _controller.SignUp(user) as ViewResult;

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(user, result.Model);
        }
    }
}
