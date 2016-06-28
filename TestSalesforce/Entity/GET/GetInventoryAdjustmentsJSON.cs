using System.Collections.Generic;

namespace InventoryManager.Entity
{
    /// <summary>
    /// 7.4 GET Inventory Adjustment
    /// </summary>
    public class GetInventoryAdjustmentsJSON : EntityModelErrorBase
    {
        public string objectName { get; set; }
        public List<ObjectFieldMap> objectFieldMaps { get; set; }
        public Attributes attributes { get; set; }

        public class ListChild
        {
            public string objectName { get; set; }
            public List<object> ListChildDetails { get; set; }
        }

        public class FieldMaps
        {
            public string pref_OnHandQty { get; set; }
            public string favouriteTag { get; set; }
            public string reasonComments { get; set; }
            public string adjustByUser { get; set; }
            public string warehouseName { get; set; }
            public string warehouseSFDCID { get; set; }
            public string preferredUOM { get; set; }
            public string productLotNumber { get; set; }
            public string productLotSFDCID { get; set; }
            public string productName { get; set; }
            public string productSFDCID { get; set; }
            public string location { get; set; }
            public string locationSFDCID { get; set; }
            public string transactionDate { get; set; }
            public string adjustedQuantity { get; set; }
            public string adjustmentReason { get; set; }
            public string adjustmentType { get; set; }
            public string inventoryAdjustmentSFDCId { get; set; }
            public string wheatInventoryAdjustmentStatus { get; set; }
        }

        public class ObjectFieldMap
        {
            public List<ListChild> listChild { get; set; }
            public FieldMaps fieldMaps { get; set; }
        }

        public class Attributes
        {
            public int returnCode { get; set; }
            public List<object> recordIds { get; set; }
            public string message { get; set; }

        }

    }
}
