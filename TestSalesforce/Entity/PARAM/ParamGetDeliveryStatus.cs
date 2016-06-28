
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.15 GET DELIVERY STATUS(WHEAT MOBILITY)
    /// </summary>
    public class ParamGetDeliveryStatus : ParamsBase
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
        /// In this call, the type and value is required.
        /// </summary>
        /// <returns></returns>
        public new bool IsValidParams()
        {
            return (IsNullOrStringEmpty(type) || IsNullOrStringEmpty(value));
        }

        /// <summary>
        /// type = SFDC Name of Bol Number – Required
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// value = SFDC value of type - Required
        /// </summary>
        public string value { get; set; }

    }
}
