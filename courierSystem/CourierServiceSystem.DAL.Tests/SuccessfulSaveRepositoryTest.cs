using NUnit.Framework;
using System.Threading.Tasks;
using courierSystem.DAL.Repositories;
using Microsoft.Data.SqlClient;

namespace courierSystem.DAL.Tests
{
    [TestFixture]
    public class SuccessfulSaveRepositoryTests
    {
        private SuccessfulSaveRepository _successfulSaveRepository;

        [SetUp]
        public void Setup()
        {
            _successfulSaveRepository = new SuccessfulSaveRepository();
        }

        [Test]
        public async Task GetLatestTrackingIdAsync_ExistingData_ReturnsLatestTrackingId()
        {
            // Act
            string result = await _successfulSaveRepository.GetLatestTrackingIdAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task GetLatestTrackingIdAsync_EmptyTable_ReturnsNull()
        {
            // Act
            string result = await _successfulSaveRepository.GetLatestTrackingIdAsync();

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public async Task GetLatestTrackingIdAsync_ExceptionThrown_ReturnsNull()
        {

            // Act
            string result = await _successfulSaveRepository.GetLatestTrackingIdAsync();

            // Assert
            Assert.IsNull(result);
        }

    }
}