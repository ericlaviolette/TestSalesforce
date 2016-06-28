using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class GetDeliveryStatusJSON : EntityModelErrorBase
    {
        public Attributes attributes { get; set; }

        public class Attributes
        {
            public int returnCode { get; set; }
            public string message { get; set; }
        }
    }
   
}
