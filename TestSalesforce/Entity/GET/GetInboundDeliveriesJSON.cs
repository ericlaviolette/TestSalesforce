using System.Collections.Generic;
using InventoryManager.Utilities;

/// <summary>
/// 7.8  GET Inbound Deliveries
/// </summary>
namespace InventoryManager.Entity
{
    // Root
    public class GetInboundDeliveriesJSON : EntityModelErrorBase
    {
        public ObjWorkOrderWrapper objWorkOrderWrapper { get; set; }
        public ObjShipmentWrapper objShipmentWrapper { get; set; }
        public Attributes attributes { get; set; }

        public class ObjWorkOrderWrapper
        {
            public IList<ListHeaderWO> listHeaderWO { get; set; }

            public class ListHeaderWO
            {
                public IList<LstAttachment> lstAttachment { get; set; }
                public IList<ListDetailWO> listDetailWO { get; set; }
                public HeaderWOFieldMap headerWOFieldMap { get; set; }
            }

            public class LstAttachment
            {
                public string name { get; set; }
                public string attachmentId { get; set; }
            }

            public class ListDetailWO
            {
                public IList<ListChild> listChild { get; set; }
                public DetailWOFieldMap detailWOFieldMap { get; set; }

                public class ListChild
                {
                    public string objectName { get; set; }
                    public IList<ListChildDetail> listChildDetails { get; set; }
                }

                public class ListChildDetail
                {
                    public ChildDetails childDetails { get; set; }
                }

                public class ChildDetails
                {
                    public string pIQDSFDCID { get; set; }
                    public string productLotName { get; set; }
                    public string productLotSFDCID { get; set; }
                    public string productId { get; set; }
                    public string productName { get; set; }
                    public string workOrderNumber { get; set; }
                    public string wOIssueId { get; set; }
                    public string pref_UOM { get; set; }
                    public string pref_OutputQuantity { get; set; }
                    public string status { get; set; }
                    public string wOCompletionId { get; set; }
                }

                public class DetailWOFieldMap
                {
                    public string workOrderDeliveryUpdate { get; set; }
                    public string lastModifiedDate { get; set; }
                    public string productName { get; set; }
                    public string productSFDCId { get; set; }
                    public string locationSFDCId { get; set; }
                    public string warehouseAccountSFDCId { get; set; }
                    public string warehouseSFDCId { get; set; }
                    public string seedCountDateTime { get; set; }
                    public string seedCount { get; set; }
                    public string estimatedQuantity { get; set; }
                    public string pref_UOM { get; set; }
                    public string productLotSFDCID { get; set; }
                    public string seedCountAverage { get; set; }
                    public string workOrderNumber { get; set; }
                    public string workOrderSFDCId { get; set; }
                }
            }

            public class HeaderWOFieldMap
            {
                public string notes { get; set; }
                public string toWarehouseZipCode { get; set; }
                public string toWarehouseCountry { get; set; }
                public string toWarehouseState { get; set; }
                public string toWarehouseCity { get; set; }
                public string toWarehouseStreet { get; set; }
                public string toWarehouseName { get; set; }
                public string fromWarehouseZipCode { get; set; }
                public string fromWarehouseCountry { get; set; }
                public string fromWarehouseState { get; set; }
                public string fromWarehouseCity { get; set; }
                public string fromWarehouseStreet { get; set; }
                public string fromWarehouseName { get; set; }
                public string orderType { get; set; }
                public string wOStatus { get; set; }
                public string expectedDeliveryDate { get; set; }
                public string workOrderNumber { get; set; }
                public string workOrderId { get; set; }
                public string shipFrom { get; set; }
            }


        }

        public class ObjShipmentWrapper
        {
            public string objectName { get; set; }
            public IList<LstShipment> lstShipment { get; set; }

            public class LstShipment
            {
                public ShipmentFieldMaps shipmentFieldMaps { get; set; }
                public IList<LstDelivery> lstDelivery { get; set; }
                public IList<LstAttachment> lstAttachment { get; set; }
            }

            public class ShipmentFieldMaps
            {
                public string toWarehouseName { get; set; }
                public string notes { get; set; }
                public string toWarehouseZipCode { get; set; }
                public string toWarehouseCountry { get; set; }
                public string toWarehouseState { get; set; }
                public string toWarehouseCity { get; set; }
                public string toWarehouseStreet { get; set; }
                public string toAccountName { get; set; }
                public string fromWarehouseZipCode { get; set; }
                public string fromWarehouseCountry { get; set; }
                public string fromWarehouseState { get; set; }
                public string fromWarehouseCity { get; set; }
                public string fromWarehouseStreet { get; set; }
                public string fromWarehouseName { get; set; }
                public string deliveryDate { get; set; }
                public string deliveryStatus { get; set; }
                public string fromAccountName { get; set; }
                public string fromAccount { get; set; }
                public string shipmentId { get; set; }
                public string shipmentName { get; set; }
                public string bolNumber { get; set; }
            }

            public class LstDelivery
            {
                public string objectName { get; set; }
                public IList<ObjectFieldMap> objectFieldMaps { get; set; }
            }

            public class LstAttachment
            {
                public string name { get; set; }
                public string attachmentId { get; set; }
            }

            public class ObjectFieldMap
            {
                public IList<ListChild> listChild { get; set; }
                public FieldMaps fieldMaps { get; set; }
            }

            public class ListChild
            {
                public string objectName { get; set; }
                public IList<ListChildDetail> listChildDetails { get; set; }
            }

            public class FieldMaps
            {
                public string transactionSource { get; set; }
                public string wheatDeliveryStatus { get; set; }
                public string lastModifiedDate { get; set; }
                public string shipmentName { get; set; }
                public string fromWarehouseAccountName { get; set; }
                public string fromWarehouseAccountID { get; set; }
                public string orderType { get; set; }
                public string bolNumber { get; set; }
                public string growerSapId { get; set; }
                public string receiptDate { get; set; }
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

            public class ListChildDetail
            {
                public ChildDetails childDetails { get; set; }
            }

            public class ChildDetails
            {
                public string warehouseSFDCId { get; set; }
                public string packageType { get; set; }
                public string seedCountStatus { get; set; }
                public string locationSFDCId { get; set; }
                public string productName { get; set; }
                public string productSFDCId { get; set; }
                public string productLotNumber { get; set; }
                public string productLotSFDCID { get; set; }
                public string seedCountDateTime { get; set; }
                public string seedCount { get; set; }
                public string uom { get; set; }
                public string status { get; set; }
                public string source { get; set; }
                public string shippedDate { get; set; }
                public string requiredDate { get; set; }
                public string shippedQuantity { get; set; }
                public string receiptDate { get; set; }
                public string promiseDate { get; set; }
                public string orderType { get; set; }
                public string receiptQueueName { get; set; }
                public string receiptQueueSFDCId { get; set; }
                public string receiptProductId { get; set; }
                public string receivedQuantity { get; set; }
                public string sellingUnitofMeasure { get; set; }
                public string receiptQueueNumber { get; set; }
                public string receiptName { get; set; }
                public string receiptSFDCId { get; set; }
            }

        }

        public class Attributes
        {
            public int returnCode { get; set; }
            public IList<object> recordIds { get; set; }
            public string message { get; set; }
        }

    }

}

