
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.8  GET Inbound Deliveries
    /// </summary>
    public class ParamGetInboundDeliveries : ParamsBase
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
            return base.IsValidParams();
        }

        /// <summary>
        /// bill of lading from delivery – Optional
        /// </summary>
        public string bolDeliveryNumber { get; set; }

        /// <summary>
        /// Warehouse SFDC Id – optional
        /// </summary>
        public string warehouseSAPId { get; set; }

        /// <summary>
        /// days in number – optional
        /// </summary>
        public string days { get; set; }

        /// <summary>
        /// delivery Status - Optional
        /// </summary>
        public string status { get; set; }
        

    }
}
