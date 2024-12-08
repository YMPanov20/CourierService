using NUnit.Framework;
using System.Threading.Tasks;
using courierSystem.DAL.Models;
using courierSystem.DAL.Repositories;
using Microsoft.Data.SqlClient;

namespace courierSystem.DAL.Tests
{
    [TestFixture]
    public class ShipmentInfoRepositoryTests
    {
        private ShipmentInfoRepository _shipmentInfoRepository;

        [SetUp]
        public void Setup()
        {
            _shipmentInfoRepository = new ShipmentInfoRepository();
        }

        [Test]
        public async Task GetShipmentInfoByIdAsync_ExistingShipmentId_ReturnsShipmentInfo()
        {
            // Arrange
            int existingShipmentId = 100000;

            // Act
            ShipmentInfo result = await _shipmentInfoRepository.GetShipmentInfoByIdAsync(existingShipmentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(existingShipmentId, result.ShipmentId);
        }

        [Test]
        public async Task GetShipmentInfoByIdAsync_NonExistingShipmentId_ReturnsEmptyShipmentInfo()
        {
            // Arrange
            int nonExistingShipmentId = 9999;

            // Act
            ShipmentInfo result = await _shipmentInfoRepository.GetShipmentInfoByIdAsync(nonExistingShipmentId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.ShipmentId);
        }

        [Test]
        public async Task UpdateDestinationOfficeNameAsync_ValidData_ReturnsNoException()
        {
            // Arrange
            int shipmentTrackingId = 456;
            string destinationOfficeName = "NewDestinationOffice";

            // Act and Assert
            Assert.DoesNotThrowAsync(async () => await _shipmentInfoRepository.UpdateDestinationOfficeNameAsync(shipmentTrackingId, destinationOfficeName));
        }

    }
}