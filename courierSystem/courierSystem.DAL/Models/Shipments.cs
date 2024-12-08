using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courierSystem.DAL.Models
{
    public class Shipments
    {
        private int shipmentId;
        private int shipmentWeight;
        private string receiverName;
        private string receiverPhoneNumber;
        private string senderPhoneNumber;
        private string senderName;
        private string officeName;
        private string shipmentDetails;
        private string shipmentStatus;

        public int ShipmentId { get { return shipmentId; } set { shipmentId = value; } }
        public int ShipmentWeight { get { return shipmentWeight; } set { shipmentWeight = value; } }
        public string ReceiverName { get { return this.receiverName; } set { this.receiverName = value; } }
        public string ReceiverPhoneNumber { get { return this.receiverPhoneNumber; } set { this.receiverPhoneNumber = value; } }
        public string SenderPhoneNumber { get { return this.senderPhoneNumber; } set { this.senderPhoneNumber = value; } }
        public string SenderName { get { return this.senderName; } set { this.senderName = value; } }
        public string OfficeName { get { return this.officeName; } set { this.officeName = value; } }
        public string ShipmentDetails { get { return this.shipmentDetails; } set { this.shipmentDetails = value; } }
        public Shipments()
        {
            ShipmentWeight = 0;
            ShipmentId = 0;
            ReceiverPhoneNumber = "";
            SenderPhoneNumber = "";
            ReceiverName = "";
            SenderName = "";
            OfficeName = "";
            ShipmentDetails = "";
        }
    }
}