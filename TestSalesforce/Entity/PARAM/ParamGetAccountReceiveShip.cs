
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.17 GET Unlisted Transact Account (Receive Ship)
    /// </summary>
    public class ParamGetAccountReceiveShip : ParamsBase
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
        /// In this call, none properties are required.
        /// </summary>
        /// <returns></returns>
        public new bool IsValidParams()
        {
            return true;
        }

        /// <summary>
        /// onlyDealers = true/false – Optional
        /// </summary>
        public string onlyDealers { get; set; }

    }
}
