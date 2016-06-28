using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class PostWorkOrderRecieveJSON  : EntityModelBase
    {
        public ObjWorkOrderParent objWorkOrderParent { get; set; }

        public class ObjWorkOrderParent
        {
            public string warehouseSFDCId { get; set; }
            public string warehouseAccountSFDCId { get; set; }
            public string workOrderType { get; set; }
            public string parentWorkOrderSFDCId { get; set; }
            public string note { get; set; }
            public IList<LstWorkOrderChild> lstWorkOrderChild { get; set; }
            public IList<LstAttachment> lstAttachment { get; set; }
        }

        public class LstWorkOrderChild
        {
            public string workOrderSFDCId { get; set; }
            public string productSFDCId { get; set; }
            public string recievedQunatity { get; set; }
            public string prefUOM { get; set; }
            public string workOrderNumber { get; set; }
        }

        public class LstAttachment
        {
            public string fileName { get; set; }
            public string base64Data { get; set; }
            public string contentType { get; set; }
        }

    }

}
