using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class GetWarehouseJSON : EntityModelErrorBase
    {
        public string objectName { get; set; }
        public IList<ObjectFieldMap> objectFieldMaps { get; set; }
        public Attributes attributes { get; set; }

        public class ListChild
        {
            public string objectName { get; set; }
            public IList<object> listChildDetails { get; set; }
        }

        public class FieldMaps
        {
            public string lastModifiedDate { get; set; }
            public string warehouseSFDCId { get; set; }
            public string sapWarehouseId { get; set; }
            public string country { get; set; }
            public string zip { get; set; }
            public object state { get; set; }
            public string city { get; set; }
            public string street { get; set; }
            public string name { get; set; }
        }

        public class ObjectFieldMap
        {
            public IList<ListChild> listChild { get; set; }
            public FieldMaps fieldMaps { get; set; }
        }

        public class Attributes
        {
            public int returnCode { get; set; }
            public string message { get; set; }
        }

    }
       
}
