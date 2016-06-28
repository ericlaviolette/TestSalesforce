using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.Entity
{
    public class UserInfos
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string sfdc_community_url { get; set; }
        public string sfdc_community_id { get; set; }
        public string signature { get; set; }
        public string scope { get; set; }
        public string id_token { get; set; }
        public string instance_url { get; set; }
        public string id { get; set; }
        public string token_type { get; set; }
        public string issued_at { get; set; }

        #region " Single Instance "
        private static UserInfos instance;
        public static UserInfos Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new UserInfos();
                }
                return instance;
            }
        }

        private UserInfos()
        {
        }
        #endregion

        public override string ToString()
        {
            string returnValue;
            returnValue = "access_token: " + Instance.access_token + Environment.NewLine;
            returnValue += "refresh_token: " + Instance.refresh_token + Environment.NewLine;
            returnValue += "sfdc_community_url: " + Instance.sfdc_community_url + Environment.NewLine;
            returnValue += "sfdc_community_id: " + Instance.sfdc_community_id + Environment.NewLine;
            returnValue += "signature: " + Instance.signature + Environment.NewLine;
            returnValue += "scope: " + Instance.scope + Environment.NewLine;
            returnValue += "id_token: " + Instance.id_token + Environment.NewLine;
            returnValue += "instance_url: " + Instance.instance_url + Environment.NewLine;
            returnValue += "id: " + Instance.id + Environment.NewLine;
            returnValue += "token_type: " + Instance.token_type + Environment.NewLine;
            returnValue += "issued_at: " + Instance.issued_at;

            return returnValue;
        }
    }
}
