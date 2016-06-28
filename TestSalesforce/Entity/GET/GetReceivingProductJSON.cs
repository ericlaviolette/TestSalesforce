using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class GetReceivingProductJSON : EntityModelErrorBase
    {
        public string objectName { get; set; }
        public IList<ObjectFieldMap> objectFieldMaps { get; set; }
        public Attributes attributes { get; set; }

        public class ObjectFieldMap
        {
            public IList<object> listChild { get; set; }
            public FieldMaps fieldMaps { get; set; }
        }

        public class Attributes
        {
            public int returnCode { get; set; }
            public IList<object> recordIds { get; set; }
            public string message { get; set; }
        }

        public class FieldMaps
        {
            public string favourite_Flag { get; set; }
            public string preferredUOM { get; set; }
            public string designationCode { get; set; }
            public string sellingUOM { get; set; }
            public string sortOrder { get; set; }
            public string uniqueProductId { get; set; }
            public string cropDesc { get; set; }
            public string isLicenseRequired { get; set; }
            public string acronymName { get; set; }
            public string packagingDesc { get; set; }
            public string treatmentDesc { get; set; }
            public string acronymCode { get; set; }
            public string specieCode { get; set; }
            public string productReference { get; set; }
            public string isService { get; set; }
            public string isActive { get; set; }
            public string productName { get; set; }
            public string productSFDCID { get; set; }
            public string lastModifiedDate { get; set; }
        }                    

    }

}
