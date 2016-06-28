using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class GetSeedCountJSON : EntityModelErrorBase
    {
        public string objectName { get; set; }
        public IList<ObjectFieldMap> objectFieldMaps { get; set; }
        public Attributes attributes { get; set; }
            

        public class FieldMaps
        {
            public string favourite_Flag { get; set; }
            public string lastModifiedDate { get; set; }
            public string seedCountUser { get; set; }
            public string locationName { get; set; }
            public string seedCountStatus { get; set; }
            public string productLotSFDCID { get; set; }
            public string pIQDSFDCID { get; set; }
            public string packageType { get; set; }
            public string productId { get; set; }
            public string productName { get; set; }
            public string warehouseSapId { get; set; }
            public string onHandQty { get; set; }
            public string pref_OnHandQty { get; set; }
            public string availableQty { get; set; }
            public string pref_AvailableQty { get; set; }
            public string blockedQty { get; set; }
            public string pref_BlockedQty { get; set; }
            public string uOM { get; set; }
            public string pref_UOM { get; set; }
            public string lotNumber { get; set; }
            public string seedCount { get; set; }
            public string seedCountUserId { get; set; }
            public string seedCountDateTime { get; set; }
        }

        public class ObjectFieldMap
        {
            public IList<object> listChild { get; set; }
            public FieldMaps fieldMaps { get; set; }
        }

        public class Attributes
        {
            public int returnCode { get; set; }
            public IList<object> recordIds { get; set; }
            public string message { get; set; }
        }

    }
}
