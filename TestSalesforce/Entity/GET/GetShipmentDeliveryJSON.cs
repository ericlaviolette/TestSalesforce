using System.Collections.Generic;

/// <summary>
/// 7.14 GET SHIPMENT DELIVERY(WHEAT MOBILITY)
/// </summary>
namespace InventoryManager.Entity
{
    // Root
    public class GetShipmentDeliveryJSON : EntityModelErrorBase
    {
        public string objectName { get; set; }
        public List<LstShipment> lstShipment { get; set; }
        public Attributes attributes { get; set; }

        public class ShipmentFieldMaps
        {
            public string notes { get; set; }
            public string toWarehouseName { get; set; }
            public string toWarehouseZipCode { get; set; }
            public string toWarehouseCountry { get; set; }
            public string toWarehouseState { get; set; }
            public string toWarehouseCity { get; set; }
            public string toWarehouseStreet { get; set; }
            public string fromWarehouseZipCode { get; set; }
            public string fromWarehouseCountry { get; set; }
            public string fromWarehouseState { get; set; }
            public string fromWarehouseCity { get; set; }
            public string fromWarehouseStreet { get; set; }
            public string fromWarehouseName { get; set; }
            public string deliveryDate { get; set; }
            public string deliveryStatus { get; set; }
            public string toAccountName { get; set; }
            public string toAccount { get; set; }
            public string shipmentId { get; set; }
            public string shipmentName { get; set; }
            public string bolNumber { get; set; }
            public string deliverySFDCId { get; set; }
        }

        public class ChildDetails
        {
            public string prefOrderedQuantity { get; set; }
            public string prefShippedQuantity { get; set; }
            public string toWarehouseAccountID { get; set; }
            public string productSFDCID { get; set; }
            public string seedCountDateTime { get; set; }
            public string packageType { get; set; }
            public string seedCountStatus { get; set; }
            public string seedCount { get; set; }
            public string prefUOM { get; set; }
            public string productLotSFDCID { get; set; }
            public string returnedQuantity { get; set; }
            public string quantityToBeReserved { get; set; }
            public string openQuantity { get; set; }
            public string nonStockQuantity { get; set; }
            public string lineEditableQuantity { get; set; }
            public string confirmedQuantity { get; set; }
            public string cancelledQuantity { get; set; }
            public string unconfirmedQuantity { get; set; }
            public string totalQuantityForDiscounts { get; set; }
            public string seedSize { get; set; }
            public string productLotSapId { get; set; }
            public string productLot { get; set; }
            public string reservedQuantity { get; set; }
            public string undeliveredQuantity { get; set; }
            public string orderedQuantity { get; set; }
            public string gtinNumber { get; set; }
            public string upcCode { get; set; }
            public string productCode { get; set; }
            public string productName { get; set; }
            public string salesOrderLineNumber { get; set; }
            public string salesOrderLineId { get; set; }
            public string deliveryLineId { get; set; }
            public string salesOrderNumber { get; set; }
        }

        public class ListChildDetail
        {
            public ChildDetails childDetails { get; set; }
        }

        public class ListChild
        {
            public string objectName { get; set; }
            public List<ListChildDetail> listChildDetails { get; set; }
        }

        public class FieldMaps
        {
            public string shipmentName { get; set; }
            public string toWarehouseAccountName { get; set; }
            public string toWarehouseAccountID { get; set; }
            public string bolNumber { get; set; }
            public string growerSapId { get; set; }
            public string growerAccountName { get; set; }
            public string recordTypeSFDCId { get; set; }
            public string salesOrderSFDCId { get; set; }
            public string fromLocation { get; set; }
            public string processingStatus { get; set; }
            public string deliveryStatus { get; set; }
            public string deliverySFDCID { get; set; }
            public string deliveryCreatedDate { get; set; }
            public string deliveryNumber { get; set; }
            public string deliveryName { get; set; }
            public string deliveryGroupName { get; set; }
            public string deliveryGroup { get; set; }
        }

        public class ObjectFieldMap
        {
            public List<ListChild> listChild { get; set; }
            public FieldMaps fieldMaps { get; set; }
        }

        public class LstDelivery
        {
            public string objectName { get; set; }
            public List<ObjectFieldMap> objectFieldMaps { get; set; }
        }

        public class LstShipment
        {
            public ShipmentFieldMaps shipmentFieldMaps { get; set; }
            public List<LstDelivery> lstDelivery { get; set; }
            public List<object> lstAttachment { get; set; }
        }

        public class Attributes
        {
            public int returnCode { get; set; }
            public List<object> recordIds { get; set; }
            public string message { get; set; }
        }

    }

}

