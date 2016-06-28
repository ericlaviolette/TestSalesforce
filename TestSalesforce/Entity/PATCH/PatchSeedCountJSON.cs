using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class PatchSeedCountJSON : EntityModelBase
    {
        public IList<ProductLot> productLots { get; set; }

        public class ProductLot
        {
            public string seedCount { get; set; }
            public string seedCountDateTime { get; set; }
            public string productLotSFDCID { get; set; }
            public bool forceUpdate { get; set; }
        }

    }
}
