using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCity.Domain.ExtensionMethods;

namespace SmartCity.Tests.Domain
{
    [TestClass]
    public class PersonExtensionsTest
    {
        [TestMethod]
        public void WhenPasswordHashingIsCalledWithSamePasswords_ThenResultIsIdentical()
        {
            // Arrange
            string passwordToTest = "password1234";

            // Act
            string hashedPasswordOne = PersonExtensions.PasswordHashing(passwordToTest);
            string hashedPasswordTwo = PersonExtensions.PasswordHashing(passwordToTest);

            // Assert
            Assert.AreEqual(hashedPasswordOne, hashedPasswordTwo);
        }

        [TestMethod]
        public void WhenPasswordHashingIsCalledWithDifferentPasswords_ThenResultIsDifferent()
        {
            // Arrange
            string passwordToTest = "password1234";
            string passwordToTestTwo = "password123456";

            // Act
            string hashedPasswordOne = PersonExtensions.PasswordHashing(passwordToTest);
            string hashedPasswordTwo = PersonExtensions.PasswordHashing(passwordToTestTwo);

            // Assert
            Assert.AreNotEqual(hashedPasswordOne, hashedPasswordTwo);
        }
    }
}