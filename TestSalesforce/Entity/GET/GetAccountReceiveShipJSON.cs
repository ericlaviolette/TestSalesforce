using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class GetAccountReceiveShipJSON : EntityModelErrorBase
    {
        public string objectName { get; set; }
        public IList<ObjectFieldMap> objectFieldMaps { get; set; }
        public Attributes attributes { get; set; }

        public class FieldMaps
        {
            public string accountType2 { get; set; }
            public string warehouseName { get; set; }
            public string warehouseSFDCId { get; set; }
            public string accountSFDCId { get; set; }
            public string billingPostalCode { get; set; }
            public string billingState { get; set; }
            public string billingCity { get; set; }
            public string billingStreet { get; set; }
            public string accountName { get; set; }
        }

        public class ObjectFieldMap
        {
            public IList<object> listChild { get; set; }
            public FieldMaps fieldMaps { get; set; }
        }

        public class Attributes
        {
            public int returnCode { get; set; }
            public string message { get; set; }
        }
    }

    

    
}
