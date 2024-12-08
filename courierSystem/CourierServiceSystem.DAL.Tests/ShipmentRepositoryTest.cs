using NUnit.Framework;
using System.Threading.Tasks;
using courierSystem.DAL.Models;
using courierSystem.DAL.Repositories;
using Microsoft.Data.SqlClient;

namespace courierSystem.DAL.Tests
{
    [TestFixture]
    public class ShipmentRepositoryTests
    {
        private ShipmentRepository _shipmentRepository;

        [SetUp]
        public void Setup()
        {
            _shipmentRepository = new ShipmentRepository();
        }

        [Test]
        public async Task InsertShipmentAsync_InvalidOfficeName_ThrowsException()
        {
            // Arrange
            Shipments shipment = new Shipments
            {
                ReceiverName = "John Doe",
                ReceiverPhoneNumber = "123456789",
                SenderName = "Jane Doe",
                SenderPhoneNumber = "987654321",
                ShipmentDetails = "Sample details",
                ShipmentWeight = 10,
                OfficeName = "NonExistingOffice"
            };

            // Act and Assert
            Assert.ThrowsAsync<Exception>(async () => await _shipmentRepository.InsertShipmentAsync(shipment));
        }

        [Test]
        public async Task InsertShipmentAsync_NullShipmentData_ThrowsException()
        {
            // Arrange
            Shipments shipment = null;

            // Act and Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await _shipmentRepository.InsertShipmentAsync(shipment));
        }
    }
}