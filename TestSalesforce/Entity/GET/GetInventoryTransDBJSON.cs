
namespace InventoryManager.Entity
{
    /// <summary>
    /// View InventoryTransDB
    /// </summary>
    public class GetInventoryTransDBJSON : EntityModelErrorBase
    {
        /// <summary>
        /// 7.8  GET Inbound Deliveries
        /// </summary>
        public GetInboundDeliveriesJSON GetInboundDeliveriesJSON { get; set; }

        /// <summary>
        /// 7.4 GET Inventory Adjustment
        /// </summary>
        public GetInventoryAdjustmentsJSON[] GetInventoryAdjustmentsJSON { get; set; }

        /// <summary>
        /// 7.14 GET SHIPMENT DELIVERY(WHEAT MOBILITY)
        /// Array of GetShipmentDeliveryJSON
        /// </summary>
        public GetShipmentDeliveryJSON GetShipmentDeliveryJSON { get; set; }

    }
}
