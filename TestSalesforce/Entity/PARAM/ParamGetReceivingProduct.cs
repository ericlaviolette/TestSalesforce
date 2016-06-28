
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.17 GET Unlisted Transact Account (Receive Ship)
    /// </summary>
    public class ParamGetReceivingProduct : ParamsBase
    {
        public ParamGetReceivingProduct()
        {
            base.userId = null;
        }

        /// <summary>
        /// Return the Parameters in string for query.
        /// </summary>
        /// <returns></returns>
        public string GetParamsJSON()
        {
            return base.GetParamsJSON(this);
        }

        /// <summary>
        /// In this call, the shipFromAccountId is required.
        /// </summary>
        /// <returns></returns>
        public new bool IsValidParams()
        {
            return (IsNullOrStringEmpty(shipFromAccountId));
        }

        /// <summary>
        /// shipFromAccountId= SFDC Account Id - required
        /// </summary>
        public string shipFromAccountId { get; set; }

        /// <summary>
        /// onlyCommercial= true/false – Optional
        /// </summary>
        public string onlyCommercial { get; set; }

        /// <summary>
        /// days - optional
        /// </summary>
        public string days { get; set; }

    }
}
