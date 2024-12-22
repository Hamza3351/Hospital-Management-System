using NUnit.Framework;
using HospitalManagementSystemCSharp.Refactoring;

namespace HospitalManagementSystemCSharp.Tests
{
    [TestFixture]
    public class LoginBehaviorTests
    {
        private LoginBehavior _loginBehavior;

        [SetUp]
        public void Setup()
        {
            //Setup the Login form mock
            //Assuming you have a valid Login form to pass in
            var loginForm = new Login(); 
            _loginBehavior = new LoginBehavior(loginForm);
        }

        [Test]
        public void IsValidLogin_WithCorrectCredentials_ReturnsTrue()
        {
            //Inserting correct values
            var result = _loginBehavior.IsValidLogin("admin", "pass");
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidLogin_WithIncorrectCredentials_ReturnsFalse()
        {
            //Inseting wrong values
            var result = _loginBehavior.IsValidLogin("wronguser", "wrongpass");
            //return true, must be false with wrong credintials
            Assert.IsFalse(result);
        }
    }
}
