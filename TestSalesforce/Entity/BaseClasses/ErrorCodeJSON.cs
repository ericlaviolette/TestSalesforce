using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.Entity
{
    public class ErrorCodeJSON
    {
        public ErrorCodeJSON()
        {
            errorCode = string.Empty;
            message = string.Empty;
            recordIDS = new List<string>();
        }

        public string errorCode { get; set; }
        public string message { get; set; }

        public IList<string> recordIDS { get; set; }

        public bool HasError()
        {
            if (errorCode != string.Empty || message != string.Empty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
