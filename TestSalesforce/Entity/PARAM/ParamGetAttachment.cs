
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.7  GET Attachment
    /// </summary>
    public class ParamGetAttachment : ParamsBase
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
        /// In this call, the attachmentId is required.
        /// </summary>
        /// <returns></returns>
        public new bool IsValidParams()
        {
            return (IsNullOrStringEmpty(attachmentId));
        }

        /// <summary>
        /// Attachment  Id – Required
        /// </summary>
        public string attachmentId { get; set; }

    }
}
