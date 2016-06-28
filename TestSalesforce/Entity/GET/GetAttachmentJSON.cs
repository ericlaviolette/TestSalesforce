using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{

    public class GetAttachmentJSON : EntityModelErrorBase
    {
        public string objectName { get; set; }
        public List<ObjectFieldMap> objectFieldMaps { get; set; }
        public Attributes attributes { get; set; }
        
        public class ObjectFieldMap
        {
            public List<object> listChild { get; set; }
            public FieldMaps fieldMaps { get; set; }
        }

        public class FieldMaps
        {
            public string parentSDFCId { get; set; }
            public string name { get; set; }
            public string contentType { get; set; }
            public string body { get; set; }
            public string attachmentSFDCId { get; set; }
        }

        public class Attributes
        {
            public int returnCode { get; set; }
            public List<object> recordIds { get; set; }
            public string message { get; set; }
        }             

    }
}
