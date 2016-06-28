using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class PostSeedCountJSON : EntityModelBase
    {
        public WorkOrderObj workOrderObj { get; set; }

        public class WorkOrderObj
        {
            public string workOrderId { get; set; }
            public string averageSeedCount { get; set; }
            public IList<LstSeedCountSample> lstSeedCountSample { get; set; }
        }

        public class LstSeedCountSample
        {
            public string seedCountSampleId { get; set; }
            public string seedCount { get; set; }
            public string seedCountDateTime { get; set; }
        }
        
    }
}
