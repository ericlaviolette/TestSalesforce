using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class PostReceivingUnlistedJSON : EntityModelBase
    {
        public RequestSalesorderWrapper requestSalesorderWrapper { get; set; }

        public class RequestSalesorderWrapper
        {
            public string shipFromAccountId { get; set; }
            public string shipToAccId { get; set; }
            public string vComments { get; set; }
            public string bolNumber { get; set; }
            public IList<LstAttachment> lstAttachment { get; set; }
            public IList<ProductLine> productLines { get; set; }
        }

        public class LstAttachment
        {
            public string fileName { get; set; }
            public string base64Data { get; set; }
            public string contentType { get; set; }
        }

        public class ProductLine
        {
            public string productId { get; set; }
            public string uom { get; set; }
            public IList<ProductDetailLine> productDetailLines { get; set; }
        }

        public class ProductDetailLine
        {
            public int orderQty { get; set; }
            public string lotNumber { get; set; }
            public int shippedQty { get; set; }
            public int receivedQty { get; set; }
        }
                      
    }

    

   
}
