
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.8  GET Inbound Deliveries
    /// </summary>
    public class ParamGetInventoryAdjustment : ParamsBase
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
        /// Note :either warehouseSAPId or allwarehouse should be provided
        /// </summary>
        /// <returns></returns>
        public new bool IsValidParams()
        {
            bool baseIsValid = base.IsValidParams();

            if (IsNullOrStringEmpty(warehouseSAPId) && IsNullOrStringEmpty(allwarehouse))
            {
                return false;
            }
            return baseIsValid;
        }

        /// <summary>
        /// Warehouse SAP  ID - Optional.
        /// </summary>
        public string warehouseSAPId { get; set; }

        /// <summary>
        /// True/False(If true show all Warehouse for user and if false show specified warehouse) – Optional
        /// either warehouseSAPId or allwarehouse should be provided
        /// Note : (If no parameter defined then default will PIQD+WO) – Optional
        /// </summary>
        public string allwarehouse { get; set; }

        /// <summary>
        /// Treatment Code Assignment – optional
        /// </summary>
        public string source { get; set; }

        /// <summary>
        /// Treatment Code Assignment – optional
        /// </summary>
        public string treatmentCode { get; set; }

        /// <summary>
        /// Parental Flag Assignment – optional
        /// </summary>
        public string parentalFlag { get; set; }

        /// <summary>
        /// Designation Code Assignment – optional
        /// </summary>
        public string designationCode { get; set; }

    }
}
