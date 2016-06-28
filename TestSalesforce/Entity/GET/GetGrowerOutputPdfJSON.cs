using System.Collections.Generic;

namespace InventoryManager.Entity
{
    public class GetGrowerOutputPDF : EntityModelErrorBase
    {
        public string objectName { get; set; }
        public IList<ObjectFieldMap> objectFieldMaps { get; set; }
        public Attributes attributes { get; set; }

        public class FieldMaps
        {
            public string contentType { get; set; }
            public string fileName { get; set; }
            public string body { get; set; }
        }

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
    }
    
}
