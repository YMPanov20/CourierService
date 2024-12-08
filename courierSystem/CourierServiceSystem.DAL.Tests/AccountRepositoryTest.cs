using NUnit.Framework;
using System.Threading.Tasks;
using courierSystem.DAL.Models;
using courierSystem.DAL.Repositories;
using Microsoft.Data.SqlClient;

namespace courierSystem.DAL.Tests
{
    [TestFixture]
    public class AdminAccountRepositoryTests
    {
        private AdminAccountRepository _adminAccountRepository;

        [SetUp]
        public void Setup()
        {
            _adminAccountRepository = new AdminAccountRepository();
        }

        [Test]
        public async Task GetAdminAccountByUsernameAsync_ExistingUsername_ReturnsAdminAccount()
        {
            // Arrange
            string existingUsername = "Admin";

            // Act
            AdminAccount result = await _adminAccountRepository.GetAdminAccountByUsernameAsync(existingUsername);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(existingUsername, result.Username);
        }

        [Test]
        public async Task GetAdminAccountByUsernameAsync_NonExistingUsername_ReturnsNull()
        {
            // Arrange
            string nonExistingUsername = "NonExistingAdminUser";

            // Act
            AdminAccount result = await _adminAccountRepository.GetAdminAccountByUsernameAsync(nonExistingUsername);

            // Assert
            Assert.IsNull(result);
        }
    }
}