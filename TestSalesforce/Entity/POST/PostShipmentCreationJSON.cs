using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class PostShipmentCreationJSON : EntityModelBase
    {
        public ObjSOWrapper objSOWrapper { get; set; }

        public class ObjSOWrapper
        {
            public bool isRetailOrder { get; set; }
            public string shipFromAccountId { get; set; }
            public string shipToAccountId { get; set; }
            public string shipFromWarehouseId { get; set; }
            public string shipToWarehouseId { get; set; }
            public string salesOrderComments { get; set; }
            public string bolNumber { get; set; }
            public string deliverySFDCID { get; set; }
            public string deliveryNote { get; set; }
            public string grossWeight { get; set; }
            public string tareWeight { get; set; }
            public string weightsKeyed { get; set; }
            public string driver { get; set; }
            public string licensePlate { get; set; }
            public string noOfAxle { get; set; }
            public IList<LstProduct> lstProducts { get; set; }
            public IList<LstAttachment> lstAttachment { get; set; }
        }

        public class LstProduct
        {
            public string deliveryLineId { get; set; }
            public string unitOfMeasure { get; set; }
            public string productSFDCID { get; set; }
            public string unitPrice { get; set; }
            public string orderQty { get; set; }
            public string lotSFDCID { get; set; }
            public string toWarehouseAccountId { get; set; }
            public string toWarehouseId { get; set; }
            public string comments { get; set; }
        }

        public class LstAttachment
        {
            public string fileName { get; set; }
            public string base64Data { get; set; }
            public string contentType { get; set; }
        }

    }     
}
