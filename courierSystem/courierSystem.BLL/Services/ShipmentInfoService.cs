using courierSystem.DAL.Models;
using courierSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courierSystem.BLL.Services
{
    public class ShipmentInfoService
    {
        private readonly ShipmentInfoRepository _shipmentInfoRepository;

        public ShipmentInfoService()
        {
            _shipmentInfoRepository = new ShipmentInfoRepository();
        }

        public async Task<ShipmentInfo> GetShipmentInfoByTrackingIdAsync(int shipmentId)
        {
             return await _shipmentInfoRepository.GetShipmentInfoByIdAsync(shipmentId);
        }

        public async Task UpdateShipmentDestinationAsync(int shipmentTrackingId, string NewDestinationOffice)
        {
            await _shipmentInfoRepository.UpdateDestinationOfficeNameAsync(shipmentTrackingId, NewDestinationOffice);
        }

    }
}
