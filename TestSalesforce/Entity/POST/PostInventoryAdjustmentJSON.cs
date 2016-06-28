using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class PostInventoryAdjustmentJSON : EntityModelBase
    {
        public IList<ProductInventoryAdjustmentLot> productInventoryAdjustmentLots { get; set; }
        
        public class ProductInventoryAdjustmentLot
        {
            public string warehouseSFDCID { get; set; }
            public string locationSFDCID { get; set; }
            public string productLotSFDCID { get; set; }
            public string adjustedQuantity { get; set; }
            public string adjustmentType { get; set; }
            public string transactionDate { get; set; }
            public string adjustmentReason { get; set; }
            public string productSFDCID { get; set; }
            public string note { get; set; }
            public IList<LstAttachment> lstAttachment { get; set; }
        }

        public class LstAttachment
        {
            public string fileName { get; set; }
            public string base64Data { get; set; }
            public string contentType { get; set; }
        }

    }
}
