using System.Collections.Generic;

namespace InventoryManager.Entity
{
    public class PostPatchResponseJSON : EntityModelErrorBase
    {
        public PostPatchResponseJSON()
        {
            
        }

        public int returnCode { get; set; }
        public object recordIds { get; set; }
        public string message { get; set; }
    }
}
