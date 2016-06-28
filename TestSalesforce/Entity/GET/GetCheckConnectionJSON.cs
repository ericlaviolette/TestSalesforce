using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class GetCheckConnectionJSON : EntityModelErrorBase
    {
        public int returnCode { get; set; }
        public string message { get; set; }
    }
}
