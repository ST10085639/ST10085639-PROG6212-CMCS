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
using Microsoft.Testing.Platform.TestHost;

namespace ST10085639_PROG6212_CMCS.Tests.Controllers
{
    [TestClass]
    public class ClaimControllerTests
    {
        private ApplicationDbContext _db;
        private ClaimController _controller;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("ClaimTestDb")
                .Options;

            _db = new ApplicationDbContext(options);

            //Seed Claim
            _db.Claims.Add(new Claim
            {
                ClaimID = 1,
                LecturerName = "Test Lecturer",
                HoursWorked = 10,
                HourlyRate = 100
            });
            _db.SaveChanges();

            _controller = new ClaimController(_db);

            //Mock session for Admin
            var context = new DefaultHttpContext();
            context.Session = new TestSession(); //Custom mock below
            context.Session.Set("Role", "Programme Coordinator");
            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = context
            };
        }

        [TestMethod]
        public void Approve_ShouldUpdateStatusToApproved()
        {
            //Action
            _controller.Approve(1);
            var claim = _db.Claims.First();

            //Assert
            Assert.AreEqual("Äpproved", claim.Status);
        }

        [TestMethod]
        public void Reject_ShouldUpdateStatusToRejected()
        {
            //Action
            _controller.Reject(1);
            var claim = _db.Claims.First();

            //Assert
            Assert.AreEqual("Rejected", claim.Status);
        }
    }

    // 🧰 Custom Session Mock
    public class TestSession : ISession
    {
        private readonly Dictionary<string, byte[]> _sessionStorage = new();

        public IEnumerable<string> Keys => _sessionStorage.Keys;

        public string Id => "TestSession";
        public bool IsAvailable => true;

        public void Clear() => _sessionStorage.Clear();

        public Task CommitAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;
        public Task LoadAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

        public void Remove(string key) => _sessionStorage.Remove(key);

        public void Set(string key, byte[] value) => _sessionStorage[key] = value;

        public bool TryGetValue(string key, out byte[] value) => _sessionStorage.TryGetValue(key, out value);
    }
}
