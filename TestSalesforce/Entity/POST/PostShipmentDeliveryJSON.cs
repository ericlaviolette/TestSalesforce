using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class PostShipmentDeliveryJSON : EntityModelBase
    {
        public ObjShipment objShipment { get; set; }

        public class ObjShipment
        {
            public string note { get; set; }
            public IList<LstAttachment> lstAttachment { get; set; }
            public IList<LstDelivery> lstDelivery { get; set; }
        }

        public class LstAttachment
        {
            public string fileName { get; set; }
            public string base64Data { get; set; }
            public string contentType { get; set; }
        }

        public class LstDelivery
        {
            public string deliverySFDCID { get; set; }
            public string grossWeight { get; set; }
            public string tareWeight { get; set; }
            public string weightsKeyed { get; set; }
            public string driver { get; set; }
            public string licensePlate { get; set; }
            public string noOfAxle { get; set; }
            public string bolNumber { get; set; }
            public IList<LstInvReserve> lstInvReserve { get; set; }
        }

        public class LstInvReserve
        {
            public string deliveryLineId { get; set; }
            public string productSFDCID { get; set; }
            public string toWarehouseAccountID { get; set; }
        }
        
    }     
}
