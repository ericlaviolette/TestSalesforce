using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Entity
{
    public class ViewModelReceivingDB
    {
        public string OrderType { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public string TransactionId { get; set; }
        public string ShipFrom { get; set; }
        public string ReceivingLoc { get; set; }
        public string Status { get; set; }
        public string Extra1 { get; set; }
        public string Extra2 { get; set; }
        public bool IsVisible { get; set; }

        public GetInboundDeliveriesJSON getInboundDeliveriesJSON { get; set; }
    }
}
