
namespace InventoryManager.Entity.Params
{
    /// <summary>
    /// 7.1 - GET Seed Count
    /// </summary>
    public class ParamGetSeedCount : ParamsBase
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
        ///  Warehouse SAP ID - Optional.
        /// </summary>
        public string warehouseSAPId { get; set; }

        /// <summary>
        /// = True/False(If true show all Warehouse for user and if false show specified warehouse) – Optional
        /// Note : either warehouseSAPId or allwarehouse should be provided
        /// </summary>
        public string allwarehouse { get; set; }

        /// <summary>
        /// (If no parameter defined then default will PIQD+WO) – Optional
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

        /// <summary>
        /// Package Type Assignment – optional
        /// </summary>
        public string packageTypeCode { get; set; }

        /// <summary>
        /// Tag Group Code Assignment - optional
        /// </summary>
        public string tagGroupCode { get; set; }

        /// <summary>
        /// Material Type Assignment – optional
        /// </summary>
        public string materialType { get; set; }

        /// <summary>
        /// Specie Code Assignment – optional
        /// </summary>
        public string specieCode { get; set; }

        /// <summary>
        ///  specify days in number
        /// </summary>
        public string days { get; set; } 

    }
}
