using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courierSystem.DAL.Models
{
    public class FinishAddShipment
    {
        private int shipmentDetailsId;
        private string shipmentDetailsCode;
        private string shipmentStatus;
        private string newDestinationOfficeName;
        public int ShipmentDetailsId { get { return shipmentDetailsId; } set { shipmentDetailsId = value; } }
        public string ShipmentDetailsCode { get { return shipmentDetailsCode; } set { shipmentDetailsCode = value; } }
        public string ShipmentStatus { get { return this.shipmentStatus; } set { this.shipmentStatus = value; } }
        public string NewDestinationOfficeName { get { return newDestinationOfficeName; } set { newDestinationOfficeName = value; } }

        public FinishAddShipment()
        {
            shipmentDetailsId = 0;
            ShipmentDetailsCode = "";
            ShipmentStatus = "";
            NewDestinationOfficeName = "";
        }

    }
}
