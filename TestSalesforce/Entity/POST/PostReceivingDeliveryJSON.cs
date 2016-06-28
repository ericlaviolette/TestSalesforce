using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class PostReceivingDeliveryJSON : EntityModelBase
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
            public string transactionSource { get; set; }
            public string warehouseSFDCId { get; set; }
            public IList<LstReceiptQueue> lstReceiptQueue { get; set; }
        }

        public class LstReceiptQueue
        {
            public string receiptQueueSFDCId { get; set; }
            public string warehouseSFDCId { get; set; }
            public string productSFDCId { get; set; }
            public string shippedQuantity { get; set; }
            public string receivedQuantity { get; set; }
            public string productLotSFDCId { get; set; }
        }
        
    }
    
}
