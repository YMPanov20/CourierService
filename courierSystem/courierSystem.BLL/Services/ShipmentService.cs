using courierSystem.DAL.Models;
using courierSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courierSystem.BLL.Services
{
    public class ShipmentService
    {
        private readonly ShipmentRepository _shipmentRepository;

        public ShipmentService()
        {
            _shipmentRepository = new ShipmentRepository();
        }

        public async Task<bool> AddShipmentAsync(string receiverName, string senderName, string receiverPhoneNumber, string senderPhoneNumber, string officeName, string shipmentDetails, int shipmentWeight)
        {
            await _shipmentRepository.InsertShipmentAsync(new Shipments
            {
                ShipmentWeight = shipmentWeight,
                ReceiverName = receiverName,
                SenderName = senderName,
                ReceiverPhoneNumber = receiverPhoneNumber,
                SenderPhoneNumber = senderPhoneNumber,
                OfficeName = officeName,
                ShipmentDetails = shipmentDetails,
            });

            return true;
        }
    }
}
