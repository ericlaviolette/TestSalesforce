
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.10   Get Grower Output  PDF
    /// </summary>
    public class ParamGetGrowerOutputPDF : ParamsBase
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
            return (IsNullOrStringEmpty(deliveryId));
        }

        /// <summary>
        /// Delivery ID - required
        /// </summary>
        public string deliveryId { get; set; }

        /// <summary>
        /// file name - optional - If not provided the name will be picked mentioned in the custom label assigned for the same
        /// </summary>
        public string fileName { get; set; }

    }
}
