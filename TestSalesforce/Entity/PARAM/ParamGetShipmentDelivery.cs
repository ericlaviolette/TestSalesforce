
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.14 GET SHIPMENT DELIVERY(WHEAT MOBILITY)
    /// </summary>
    public class ParamGetShipmentDelivery : ParamsBase
    {
        /// <summary>
        /// Return the Parameters in string for query.
        /// </summary>
        /// <returns></returns>
        public string GetParamsJSON()
        {
            return base.GetParamsJSON(this);
        }

        /// <summary>
        /// In this call, the userId is required.
        /// </summary>
        /// <returns></returns>
        public new bool IsValidParams()
        {
            bool baseIsValid = base.IsValidParams();
          
            return baseIsValid;
        }

        /// <summary>
        /// bill of lading for delivery–Optional
        /// </summary>
        public string bolDeliveryNumber { get; set; }

        /// <summary>
        /// Year – optional
        /// </summary>
        public string year { get; set; }

        /// <summary>
        /// SFDC Warehouse SAP id – optional
        /// </summary>
        public string warehouseSAPId { get; set; }

        /// <summary>
        /// delivery Status - Optional
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// number of days - Optional
        /// </summary>
        public string days { get; set; }

    }
}
