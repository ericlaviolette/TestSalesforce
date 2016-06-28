
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.13 GET WAREHOUSE(WHEAT MOBILITY)
    /// </summary>
    public class ParamGetWarehouse : ParamsBase
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
        /// defaultWarehouse - optional - True/False
        /// </summary>
        public string defaultWarehouse { get; set; }
    }
}
