using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courierSystem.DAL.Models
{
    public class ShipmentInfo
    {
        private int shipmentId;
        private int shipmentWeight;
        private string receiverName;
        private string senderName;
        private string receiverPhoneNumber;
        private string senderPhoneNumber;
        private string shipmentDetails;
        private string sourceOfficeName;
        private string destinationOfficeName;

        public int ShipmentId { get { return shipmentId; } set { shipmentId = value; } }
        public int ShipmentWeight { get { return shipmentWeight; } set { shipmentWeight = value; } }
        public string ReceiverName { get { return receiverName; } set { receiverName = value; } }
        public string SenderName { get { return senderName; } set { senderName = value; } }
        public string ReceiverPhoneNumber { get { return receiverPhoneNumber; } set { receiverPhoneNumber = value; } }
        public string SenderPhoneNumber { get { return senderPhoneNumber; } set { senderPhoneNumber = value; } }
        public string ShipmentDetails { get { return shipmentDetails; } set { shipmentDetails = value; } }
        public string SourceOfficeName { get { return sourceOfficeName; } set { sourceOfficeName = value; } }
        public string DestinationOfficeName { get { return destinationOfficeName; } set { destinationOfficeName = value; } }


        public ShipmentInfo()
        {
            ShipmentId = 0;
            ShipmentWeight = 0;
            ReceiverName = "";
            SenderName = "";
            ReceiverPhoneNumber = "";
            SenderPhoneNumber = "";
            ShipmentDetails = "";
            SourceOfficeName = "";
            DestinationOfficeName = "";
        }
    }
}
