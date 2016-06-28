using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager.LocalService
{
    public class ConnectionInfos
    {        
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

        public string code { get; set; }
        public string sfdc_community_url { get; set; }
        public string sfdc_community_id { get; set; }

        public string LoginPassword { get { return Password + Token; } }

        public ConnectionInfos()
        {
            //set OAuth key and secret variables
            const string sfdcConsumerKey = "3MVG98dostKihXN5k6aV.ZUmKpFM8AJ1h5PcOQgS_P4B5Ko75j3uxF1FilYs8SqMrv_Z3n4l24IpevjKB3ssN";
            const string sfdcConsumerSecret = "2690845714756692471";
            //set to Force.com user account that has API access enabled
            const string sfdcUserName = "ravikumar.kanasagra@in.fujitsu.com.liondev";
            const string sfdcPassword = "Xamarin@1234";
            const string sfdcToken = "YuLF7KnQFuzE3zKvQE3vQIMG";

            //const string sfdcUserName = "testxamarin@usliondev.com";
            //const string sfdcPassword = "Sfdc12345";
            //const string sfdcToken = "";

            init(sfdcConsumerKey, sfdcConsumerSecret, sfdcUserName, sfdcPassword, sfdcToken);
        }

        public ConnectionInfos(string consumerKey, string ConsumerSecret, string userName, string password, string token)
        {
            init(consumerKey, ConsumerSecret, userName, password, token);
        }

        private void init(string consumerKey, string consumerSecret, string userName, string password, string token)
        {
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            UserName = userName;
            Password = password;
            Token = token;
        }

    }
}
