using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Entity
{
    public class UserInfosOld
    {
        public string access_token { get; set; }
        public string instance_url { get; set; }
        public string id { get; set; }
        public string token_type { get; set; }
        public string issued_at { get; set; }
        public string signature { get; set; }

        public override string ToString()
        {
            string returnValue;
            returnValue = "access_token: " + access_token + Environment.NewLine;
            returnValue += "instance_url: " + instance_url + Environment.NewLine;
            returnValue += "id: " + id + Environment.NewLine;
            returnValue += "token_type: " + token_type + Environment.NewLine;
            returnValue += "issued_at: " + issued_at + Environment.NewLine;
            returnValue += "signature: " + signature;

            return returnValue;
        }
    }
}
