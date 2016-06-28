﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using InventoryManager.Entity;
using InventoryManager.Entity.Params;
using Newtonsoft.Json;

namespace InventoryManager.LocalService
{

    public class Data
    {

        #region " Private Variables and Const "

        private bool isConnected;

        // For USLIONDEV use
        // private const string UrlAuthClient = "https://usliondev-mon.cs1.force.com/wheatComm"
        // For USQA use
        // private const string UrlAuthClient = "https://usqa-mon.cs30.force.com/wheatCommunity"
        // For Test connection use
        // private const string UrlAuthClient = "https://test.salesforce.com/services/oauth2/token";
        //"https://monsanto-us--usliondev.cs1.my.salesforce.com/app/mgmt/forceconnectedapps/forceAppDetail.apexp?applicationId=06PS00000004CLi&id=0CiS00000008WDX"
        private const string UrlAuthClientOld = "https://test.salesforce.com/services/oauth2/token";
        //private const string UrlAuthClient = "https://usliondev-mon.cs1.force.com/wheatComm/services/oauth2/token";

        private const string UrlAuthClient = "https://usliondev-mon.cs1.force.com/wheatComm/services/oauth2/authorize";
        private const string UrlAuthSuccess = "https://usliondev-mon.cs1.force.com/services/oauth2/success";
        private const string UrlAuthToken = "https://usliondev-mon.cs1.force.com/wheatComm/services/oauth2/token";

        private const string UrlBase = "/services/apexrest/";
        private const string UrllocationCompass = "Compass/";
        private const string UrllocationWheatMobile = "WheatMobile/";
        private const string UrllocationWITS = "WITS/";
        private const string AutorizationWord = "Authorization";
        private const string BearerWord = "Bearer ";
        private const string AppJSonWord = "application/json";
        #endregion

        #region " Public Variables and Properties "
        public UserInfos userInfos;
        public string serviceUrl;

        public bool IsConnected { get { return isConnected; } }

        public string LastQueryURL { get; set; }
        public string LastResultString { get; set; }
        #endregion

        #region " Single Instance "
        private static Data instance;
        public static Data Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Data();
                }
                return instance;
            }
        }

        private Data()
        {
        }
        #endregion

        #region " Connection to Salesforce "

        /// <summary>
        /// Connection to Salesforce using UserName, Password and Token
        /// </summary>
        /// <param name="connectInfos">Credentials from the User</param>
        /// <returns>True if connected.</returns>
        public async Task<bool> ConnectQA(ConnectionInfos connectInfos)
        {
            isConnected = false;
            LastQueryURL = string.Empty;
            LastResultString = string.Empty;
            userInfos = UserInfos.Instance;

            HttpClient authClient = new HttpClient();

            //set OAuth key and secret variables
            string sfdcConsumerKey = connectInfos.ConsumerKey;
            string sfdcConsumerSecret = connectInfos.ConsumerSecret;

            //set to Force.com user account that has API access enabled
            string sfdcUserName = connectInfos.UserName;
            string sfdcPassword = connectInfos.Password;
            string sfdcToken = connectInfos.Token;

            string restQuery = UrlAuthClient + "?response_type=code&client_id=" + sfdcConsumerKey + "&redirect_uri=" + UrlAuthSuccess;
            
            HttpClient queryClient = new HttpClient();
            ////new Http message
            //HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, restQuery);
            HttpResponseMessage response = await queryClient.GetAsync(restQuery);
            
            //call endpoint async
            //HttpResponseMessage response = await queryClient.GetAsync(restQuery);
            //read string result
            string result = await response.Content.ReadAsStringAsync();

            if (!StringIsNullOrEmpty(result))
            {
                JObject obj = JObject.Parse(result);

                string errorType = (string)obj["error"];
                string errorDesc = (string)obj["error_description"];
                
                if (!StringIsNullOrEmpty(errorType) && !StringIsNullOrEmpty(errorDesc))
                {
                    isConnected = false;
                    LastResultString = "Error type: " + errorType + " - Error Description: " + errorDesc;
                }
                else
                {
                    connectInfos.code = (string)obj["code"];
                    connectInfos.sfdc_community_url = (string)obj["sfdc_community_url"];
                    connectInfos.sfdc_community_id = (string)obj["sfdc_community_id"];

                    HttpContent content = new FormUrlEncodedContent(new Dictionary<string, string>
                      {
                         {"grant_type", "authorization_code"},
                         {"code", connectInfos.code},
                         {"client_id", sfdcConsumerKey},
                         {"client_secret", sfdcConsumerSecret},
                         {"redirect_uri", UrlAuthSuccess}
                       }
                    );

                    HttpResponseMessage message = await authClient.PostAsync(UrlAuthToken, content);

                    string responseString = await message.Content.ReadAsStringAsync();

                    if (!StringIsNullOrEmpty(responseString))
                    {
                        userInfos = JsonConvert.DeserializeObject<UserInfos>(responseString);

                        isConnected = true;
                        LastResultString = "Infos sended to Connect to Salesforce:" + Environment.NewLine +
                                            "ConsumerKey: " + sfdcConsumerKey + Environment.NewLine +
                                            "ConsumerSecret: " + sfdcConsumerSecret + Environment.NewLine +
                                            "UserName: " + sfdcUserName + Environment.NewLine +
                                            "Password: " + sfdcPassword + Environment.NewLine +
                                            "Token: " + sfdcToken + Environment.NewLine + Environment.NewLine +
                                            "Returned infos from Connection Call:" + Environment.NewLine +
                                            userInfos.ToString();
                    }
                }
            }

            return isConnected;
        }

        /// <summary>
        /// Connection to Salesforce using UserName, Password and Token
        /// </summary>
        /// <param name="connectInfos">Credentials from the User</param>
        /// <returns>True if connected.</returns>
        public async Task<bool> Connect(ConnectionInfos connectInfos)
        {
            isConnected = false;
            LastQueryURL = string.Empty;
            LastResultString = string.Empty;
            userInfos = UserInfos.Instance;

            HttpClient authClient = new HttpClient();

            //set OAuth key and secret variables
            string sfdcConsumerKey = connectInfos.ConsumerKey;
            string sfdcConsumerSecret = connectInfos.ConsumerSecret;

            //set to Force.com user account that has API access enabled
            string sfdcUserName = connectInfos.UserName;
            string sfdcPassword = connectInfos.Password;
            string sfdcToken = connectInfos.Token;

            //create login password value
            string loginPassword = connectInfos.LoginPassword;

            HttpContent content = new FormUrlEncodedContent(new Dictionary<string, string>
              {
                 {"grant_type", "password"},
                 {"client_id", sfdcConsumerKey},
                 {"client_secret", sfdcConsumerSecret},
                 {"username", sfdcUserName},
                 {"password", loginPassword}
               }
            );

            HttpResponseMessage message = await authClient.PostAsync(UrlAuthClientOld, content);

            string responseString = await message.Content.ReadAsStringAsync();

            if (!StringIsNullOrEmpty(responseString))
            {
                JObject obj = JObject.Parse(responseString);

                string errorType = (string)obj["error"];
                string errorDesc = (string)obj["error_description"];

                if (!StringIsNullOrEmpty(errorType) && !StringIsNullOrEmpty(errorDesc))
                {
                    isConnected = false;
                    LastResultString = "Error type: " + errorType + " - Error Description: " + errorDesc;
                }
                else
                {
                    userInfos.access_token = (string)obj["access_token"];
                    userInfos.instance_url = (string)obj["instance_url"];
                    userInfos.id = (string)obj["id"];
                    userInfos.token_type = (string)obj["token_type"];
                    userInfos.issued_at = (string)obj["issued_at"];
                    userInfos.signature = (string)obj["signature"];

                    // Constante de l'URL
                    serviceUrl = userInfos.instance_url;

                    isConnected = true;
                    LastResultString = "Infos sended to Connect to Salesforce:" + Environment.NewLine +
                                       "ConsumerKey: " + sfdcConsumerKey + Environment.NewLine +
                                       "ConsumerSecret: " + sfdcConsumerSecret + Environment.NewLine +
                                       "UserName: " + sfdcUserName + Environment.NewLine +
                                       "Password: " + sfdcPassword + Environment.NewLine +
                                       "Token: " + sfdcToken + Environment.NewLine + Environment.NewLine +
                                       "Returned infos from Connection Call:" + Environment.NewLine +
                                       userInfos.ToString();
                }
            }

            return isConnected;
        }

        #endregion

        #region " Private Methods (API calls) GetData, PostData, PatchData "
        /// <summary>
        /// Get Data aSync
        /// </summary>
        /// <param name="locationURL"></param>
        /// <param name="queryURL"></param>
        /// <returns></returns>
        private async Task<string> GetData(string locationURL, string queryURL)
        {
            string result = string.Empty;

            string restQuery = serviceUrl + UrlBase + locationURL + queryURL;
            LastQueryURL = restQuery;

            HttpClient queryClient = new HttpClient();

            //new Http message
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, restQuery);

            //add token to header
            request.Headers.Add(AutorizationWord, BearerWord + userInfos.access_token);

            //return JSON to the caller
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(AppJSonWord));

            //call endpoint async
            HttpResponseMessage response = await queryClient.SendAsync(request);

            //read string result
            result = await response.Content.ReadAsStringAsync();
            LastResultString = result;

            return result;
        }

        /// <summary>
        /// Post Data aSync
        /// </summary>
        /// <param name="locationURL"></param>
        /// <param name="queryURL"></param>
        /// <returns></returns>
        private async Task<string> PostData(string locationURL, string queryURL, EntityModelBase objPost)
        {
            string result = string.Empty;

            string restQuery = serviceUrl + UrlBase + locationURL + queryURL;
            LastQueryURL = restQuery;

            HttpClient queryClient = new HttpClient();

            //add token to header
            queryClient.DefaultRequestHeaders.Add(AutorizationWord, BearerWord + userInfos.access_token);

            //return JSON to the caller
            queryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AppJSonWord));

            // SerializeObject
            string postBody = JsonConvert.SerializeObject(objPost);

            // Body Content JSON Values
            StringContent bodyContent = new StringContent(postBody, Encoding.UTF8, AppJSonWord);

            //call endpoint async
            HttpResponseMessage response = await queryClient.PostAsync(restQuery, bodyContent);

            //read string result
            result = await response.Content.ReadAsStringAsync();
            LastResultString = result;

            return result;
        }

        /// <summary>
        /// Patch Data aSync (in Progress)
        /// </summary>
        /// <param name="locationURL"></param>
        /// <param name="queryURL"></param>
        /// <returns></returns>
        private async Task<string> PatchData(string locationURL, string queryURL, EntityModelBase objPost)
        {
            string result = string.Empty;

            string restQuery = serviceUrl + UrlBase + locationURL + queryURL;
            LastQueryURL = restQuery;

            HttpClient queryClient = new HttpClient();

            //add token to header
            queryClient.DefaultRequestHeaders.Add(AutorizationWord, BearerWord + userInfos.access_token);

            //return JSON to the caller
            queryClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AppJSonWord));

            // SerializeObject
            string postBody = JsonConvert.SerializeObject(objPost);

            // Body Content JSON Values
            StringContent bodyContent = new StringContent(postBody, Encoding.UTF8, AppJSonWord);

            var method = new HttpMethod("PATCH");

            var request = new HttpRequestMessage(method, restQuery)
            {
                Content = bodyContent
            };

            //call endpoint async
            HttpResponseMessage response = await queryClient.SendAsync(request);

            //call endpoint async
            //HttpResponseMessage response = await queryClient.PostAsync(restQuery, bodyContent);

            //read string result
            result = await response.Content.ReadAsStringAsync();
            LastResultString = result;

            return result;
        }
        #endregion

        #region " Private Methods "

        /// <summary>
        /// Verify if a string is null or empty
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Boolean</returns>
        private bool StringIsNullOrEmpty(string text)
        {
            if ((text == null) || (text == String.Empty))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Get the Error code in class from JSON string
        /// </summary>
        /// <param name="result">JSON string</param>
        /// <returns>Class ErrorCodeJSON</returns>
        private ErrorCodeJSON[] ReturnErrorJSON(string result)
        {
            ErrorCodeJSON[] errorCodeJSON = new ErrorCodeJSON[0];

            errorCodeJSON = JsonConvert.DeserializeObject<ErrorCodeJSON[]>(result);

            return errorCodeJSON;
        }

        /// <summary>
        /// Verify if result in JSON string contains errorCode
        /// </summary>
        /// <param name="result">JSON string</param>
        /// <returns></returns>
        private bool IsResultValid(string result)
        {
            if (result.Contains("errorCode"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region " API GETs "

        #region " Inbound Deliveries "
        /// <summary>
        /// 7.8  GET Inbound Deliveries (Receiving)
        /// </summary>
        /// <example>12.25	Get Inventory Adjustment (Wheat Mobility)
        /// InventoryAdjustment?userId=00530000007uHB7&allwarehouse=true</example>
        /// <returns>Class GetInboundDeliveriesJSON</returns>
        public async Task<GetInboundDeliveriesJSON> GetInboundDeliveries(ParamGetInboundDeliveries paramGetInboundDeliveries)
        {
            string result = string.Empty;

            GetInboundDeliveriesJSON getInboundDeliveriesJSON = new GetInboundDeliveriesJSON();

            result = await GetInboundDeliveriesString(paramGetInboundDeliveries);

            if (IsResultValid(result))
            {
                getInboundDeliveriesJSON = JsonConvert.DeserializeObject<GetInboundDeliveriesJSON>(result);
            }
            else
            {
                getInboundDeliveriesJSON.ErrorsReturn = ReturnErrorJSON(result);
            }

            return getInboundDeliveriesJSON;
        }

        /// <summary>
        /// 7.8  GET Inbound Deliveries (Receiving)
        /// </summary>
        /// <example>12.25	Get Inventory Adjustment (Wheat Mobility)
        /// InventoryAdjustment?userId=00530000007uHB7&allwarehouse=true</example>
        /// <returns>String query in JSON format</returns>
        internal async Task<string> GetInboundDeliveriesString(ParamGetInboundDeliveries paramGetInboundDeliveries)
        {
            string result = string.Empty;
            bool isConnect = false;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                string queryURL = "ReceivingDeliveryDetails";
                //string queryURL = "ReceivingDeliveryDetails?userId=005S0000004P2C6";
                //string queryURL = "ReceivingDeliveryDetails?userId=" + userInfos.id;

                queryURL += paramGetInboundDeliveries.GetParamsJSON();

                //queryURL = "ReceivingDeliveryDetails?days=60&userId=005S0000004vE0G";

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Inventory Adjustment "
        /// <summary>
        /// 7.4 GET Inventory Adjustment
        /// </summary>
        /// <example>12.25	Get Inventory Adjustment (Wheat Mobility)
        /// InventoryAdjustment?userId=005S0000004OzgmIAC&allwarehouse=true</example>
        /// <returns>Array Of GetInventoryAdjustmentsJSON</returns>
        public async Task<GetInventoryAdjustmentsJSON[]> GetInventoryAdjustment(ParamGetInventoryAdjustment paramGetInventoryAdjustment)
        {
            string result = string.Empty;

            GetInventoryAdjustmentsJSON[] getInventoryAdjustmentsJSON = new GetInventoryAdjustmentsJSON[0];

            result = await GetInventoryAdjustmentString(paramGetInventoryAdjustment);

            if (IsResultValid(result))
            {
                getInventoryAdjustmentsJSON = JsonConvert.DeserializeObject<GetInventoryAdjustmentsJSON[]>(result);
            }
            else
            {
                getInventoryAdjustmentsJSON[0].ErrorsReturn = ReturnErrorJSON(result);
            }

            return getInventoryAdjustmentsJSON;
        }

        /// <summary>
        /// 7.4 GET Inventory Adjustment
        /// </summary>
        /// <example>12.25	Get Inventory Adjustment (Wheat Mobility)
        /// InventoryAdjustment?userId=005S0000004OzgmIAC&allwarehouse=true</example>
        /// <returns>String query in JSON format</returns>
        internal async Task<string> GetInventoryAdjustmentString(ParamGetInventoryAdjustment paramGetInventoryAdjustment)
        {
            string result = string.Empty;
            bool isConnect = false;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                string queryURL = "InventoryAdjustment";
                //string queryURL = "InventoryAdjustment?userId=005S0000004P2C6&allwarehouse=true";
                //string queryURL = "InventoryAdjustment?userId=" + userInfos.id + "&allwarehouse=true";

                queryURL += paramGetInventoryAdjustment.GetParamsJSON();

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Shipment Delivery "
        /// <summary>
        /// 7.14 GET SHIPMENT DELIVERY(WHEAT MOBILITY)
        /// </summary>
        /// <example>12.30	GET Shipment Delivery(Shipping) (Wheat Mobility) 
        /// ShippingDeliveryDetails?userId=005S0000004PM2G&days=30</example>
        /// <returns>Class GetShipmentDeliveryJSON</returns>
        public async Task<GetShipmentDeliveryJSON> GetShipmentDelivery(ParamGetShipmentDelivery paramGetShipmentDelivery)
        {
            string result = string.Empty;

            GetShipmentDeliveryJSON getShipmentDeliveryJSON = new GetShipmentDeliveryJSON();

            result = await GetShipmentDeliveryString(paramGetShipmentDelivery);

            if (IsResultValid(result))
            {
                getShipmentDeliveryJSON = JsonConvert.DeserializeObject<GetShipmentDeliveryJSON>(result);
            }
            else
            {
                getShipmentDeliveryJSON.ErrorsReturn = ReturnErrorJSON(result);
            }

            return getShipmentDeliveryJSON;
        }

        /// <summary>
        /// 7.14 GET SHIPMENT DELIVERY(WHEAT MOBILITY)
        /// </summary>
        /// <example>12.30	GET Shipment Delivery(Shipping) (Wheat Mobility) 
        /// ShippingDeliveryDetails?userId=005S0000004PM2G&days=30</example>
        /// <returns>String query in JSON format</returns>
        public async Task<String> GetShipmentDeliveryString(ParamGetShipmentDelivery paramGetShipmentDelivery)
        {
            string result = string.Empty;
            bool isConnect = false;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                string queryURL = "ShippingDeliveryDetails";
                //string queryURL = "ShippingDeliveryDetails?userId=005S0000004P2C6&days=30";
                //string queryURL = "ShippingDeliveryDetails?userId=" + userInfos.id + "&days=30";

                queryURL += paramGetShipmentDelivery.GetParamsJSON();

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Inventory Transactions Dashboard "
        /// <summary>
        /// Data for the View InventoryTransDB
        /// </summary>
        /// <returns>Class GetInventoryTransDBJSON, contains classes: GetInboundDeliveriesJSON, GetInventoryAdjustmentsJSON, GetShipmentDeliveryJSON</returns>
        public async Task<GetInventoryTransDBJSON> GetInventoryTransDB(ParamGetInboundDeliveries paramGetInboundDeliveries,
                                                                       ParamGetInventoryAdjustment paramGetInventoryAdjustment,
                                                                       ParamGetShipmentDelivery paramGetShipmentDelivery)
        {
            string allResults;

            GetInventoryTransDBJSON getInventoryTransDBJSON = new GetInventoryTransDBJSON();

            allResults = "Calling API GetInventoryTransDB..." + Environment.NewLine + Environment.NewLine;

            allResults += "Calling API GetInboundDeliveries..." + Environment.NewLine;
            getInventoryTransDBJSON.GetInboundDeliveriesJSON = await GetInboundDeliveries(paramGetInboundDeliveries);
            allResults += LastQueryURL + Environment.NewLine;
            allResults += "Return values from API call: " + Environment.NewLine + LastResultString + Environment.NewLine + Environment.NewLine;
            allResults += Environment.NewLine + new String('-', 240) + Environment.NewLine + new String('-', 240);
            LastResultString = string.Empty;
            LastQueryURL = string.Empty;

            allResults += "Calling API GetInventoryAdjustment..." + Environment.NewLine;
            getInventoryTransDBJSON.GetInventoryAdjustmentsJSON = await GetInventoryAdjustment(paramGetInventoryAdjustment);
            allResults += LastQueryURL + Environment.NewLine;
            allResults += "Return values from API call: " + Environment.NewLine + LastResultString + Environment.NewLine + Environment.NewLine;
            allResults += Environment.NewLine + new String('-', 240) + Environment.NewLine + new String('-', 240);
            LastResultString = string.Empty;
            LastQueryURL = string.Empty;

            allResults += "Calling API GetShipmentDelivery..." + Environment.NewLine;
            getInventoryTransDBJSON.GetShipmentDeliveryJSON = await GetShipmentDelivery(paramGetShipmentDelivery);
            allResults += LastQueryURL + Environment.NewLine;
            allResults += "Return values from API call: " + Environment.NewLine + LastResultString + Environment.NewLine + Environment.NewLine;
            allResults += Environment.NewLine + new String('-', 240) + Environment.NewLine + new String('-', 240);

            LastQueryURL = string.Empty;
            LastResultString = allResults;

            return getInventoryTransDBJSON;
        }
        #endregion

        #region " Attachment "
        /// <summary>
        /// 7.7  GET Attachment
        /// </summary>
        /// <example>12.28	Get Attachment (Wheat Mobility)
        /// Attachment?attachmentId=00PS00000020fcz</example>
        /// <returns>Array Of GetAttachmentJSON</returns>
        /// <TestCall>GetAttachmentJSON[] getAttachmentJSON = await GetAttachment("");</Test>
        public async Task<GetAttachmentJSON[]> GetAttachment(ParamGetAttachment paramGetAttachment)
        {
            string result = string.Empty;

            GetAttachmentJSON[] getAttachmentJSON = new GetAttachmentJSON[0];

            result = await GetAttachmentString(paramGetAttachment);

            if (IsResultValid(result))
            {
                getAttachmentJSON = JsonConvert.DeserializeObject<GetAttachmentJSON[]>(result);
            }
            else
            {
                getAttachmentJSON[0].ErrorsReturn = ReturnErrorJSON(result);
            }

            return getAttachmentJSON;
        }

        /// <summary>
        /// 7.7  GET Attachment
        /// </summary>
        /// <example>12.28	Get Attachment (Wheat Mobility)
        /// Attachment?attachmentId=00PS00000020fcz</example>
        /// <returns>String query in JSON format</returns>
        /// <TestCall>GetAttachmentJSON[] getAttachmentJSON = await GetAttachment("");</Test>
        public async Task<String> GetAttachmentString(ParamGetAttachment paramGetAttachment)
        {
            string result = string.Empty;
            bool isConnect = false;
            string queryURL;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {

                queryURL = "Attachment";
                //queryURL = "Attachment?attachmentId=00PS00000020fcz";

                queryURL += paramGetAttachment.GetParamsJSON();

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Seed Count "
        /// <summary>
        /// 7.1  GET Seed Count
        /// </summary>
        /// <example>12.22	Get Seed Count (Wheat Mobility)
        /// SeedsCount?userId=00530000007uHB7&warehouseSAPId=45678&days=30</example>
        /// <returns>Array of GetSeedCountJSON</returns>
        public async Task<GetSeedCountJSON[]> GetSeedCount(ParamGetSeedCount paramGetSeedCount)
        {
            string result = string.Empty;

            GetSeedCountJSON[] getSeedCountJSON = new GetSeedCountJSON[0];

            result = await GetSeedCountString(paramGetSeedCount);

            if (IsResultValid(result))
            {
                getSeedCountJSON = JsonConvert.DeserializeObject<GetSeedCountJSON[]>(result);
            }
            else
            {
                getSeedCountJSON[0].ErrorsReturn = ReturnErrorJSON(result);
            }

            return getSeedCountJSON;
        }

        /// <summary>
        /// 7.1  GET Seed Count
        /// </summary>
        /// <example>12.22	Get Seed Count (Wheat Mobility)
        /// SeedsCount?userId=00530000007uHB7&warehouseSAPId=45678&days=30</example>
        /// <returns>String query in JSON format</returns>
        public async Task<String> GetSeedCountString(ParamGetSeedCount paramGetSeedCount)
        {
            string result = string.Empty;
            bool isConnect = false;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                string queryURL = "SeedsCount";
                //string queryURL = "SeedsCount?userId=005S0000004P2C6";
                //string queryURL = "SeedsCount?userId=005S0000004P2C6&days=30";
                //string queryURL = "SeedsCount?userId=00530000007uHB7&warehouseSAPId=45678&days=30";

                queryURL += paramGetSeedCount.GetParamsJSON();

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Grower Output PDF "
        /// <summary>
        /// 7.10   Get Grower Output  PDF
        /// </summary>
        /// <example>12.34	Get Grower Output PDF (Wheat Mobility)
        /// PlantingRecommendationPDF?deliveryId=a5FS0000000139x&fileName=filetest
        /// <returns>Array Of GetGrowerOutputPDF</returns>
        public async Task<GetGrowerOutputPDF[]> GetGrowerOutputPDF(ParamGetGrowerOutputPDF paramGetGrowerOutputPDF)
        {
            string result = string.Empty;

            GetGrowerOutputPDF[] getGrowerOutputPDF = new GetGrowerOutputPDF[0];

            result = await GetGrowerOutputPDFString(paramGetGrowerOutputPDF);

            if (IsResultValid(result))
            {
                getGrowerOutputPDF = JsonConvert.DeserializeObject<GetGrowerOutputPDF[]>(result);
            }
            else
            {
                getGrowerOutputPDF[0].ErrorsReturn = ReturnErrorJSON(result);
            }

            return getGrowerOutputPDF;
        }

        /// <summary>
        /// 7.10   Get Grower Output  PDF
        /// </summary>
        /// <example>12.34	Get Grower Output PDF (Wheat Mobility)
        /// PlantingRecommendationPDF?deliveryId=a5FS0000000139x&fileName=filetest
        /// <returns>String query in JSON format</returns>
        public async Task<String> GetGrowerOutputPDFString(ParamGetGrowerOutputPDF paramGetGrowerOutputPDF)
        {
            string result = string.Empty;
            bool isConnect = false;
            string queryURL;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                queryURL = "PlantingRecommendationPDF";
                //queryURL = "PlantingRecommendationPDF?deliveryId=a5FS0000000139x&fileName=filetest";

                queryURL += paramGetGrowerOutputPDF.GetParamsJSON();

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Warehouse "
        /// <summary>
        /// 7.13 GET WAREHOUSE(WHEAT MOBILITY)
        /// </summary>
        /// <example>12.35	Get Warehouse (Wheat Mobility)
        /// Warehouses?userId=00530000007uHB7
        /// <returns>Class GetWarehouseJSON</returns>
        public async Task<GetWarehouseJSON> GetWarehouse(ParamGetWarehouse paramGetWarehouse)
        {
            string result = string.Empty;

            GetWarehouseJSON getWarehouseJSON = new GetWarehouseJSON();

            result = await GetWarehouseString(paramGetWarehouse);

            if (IsResultValid(result))
            {
                getWarehouseJSON = JsonConvert.DeserializeObject<GetWarehouseJSON>(result);
            }
            else
            {
                getWarehouseJSON.ErrorsReturn = ReturnErrorJSON(result);
            }

            return getWarehouseJSON;
        }

        /// <summary>
        /// 7.13 GET WAREHOUSE(WHEAT MOBILITY)
        /// </summary>
        /// <example>12.35	Get Warehouse (Wheat Mobility)
        /// Warehouses?userId=00530000007uHB7
        /// <returns>String query in JSON format</returns>
        public async Task<String> GetWarehouseString(ParamGetWarehouse paramGetWarehouse)
        {
            string result = string.Empty;
            bool isConnect = false;
            string queryURL;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {

                //queryURL = "Warehouses";
                //queryURL = "Warehouses?userId=005S0000004P2C6";
                queryURL = "Warehouses";

                queryURL += paramGetWarehouse.GetParamsJSON();

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Delivery Status "
        /// <summary>
        /// 7.15 GET DELIVERY STATUS(WHEAT MOBILITY)
        /// </summary>
        /// <example>12.36 Get Delivery Status (Wheat Mobility)
        /// DeliverySearch/?type=BillofLading__c&value=BOLa3FS00000002YySMA1
        /// <returns>Class GetDeliveryStatusJSON</returns>
        public async Task<GetDeliveryStatusJSON> GetDeliveryStatus(ParamGetDeliveryStatus paramGetDeliveryStatus)
        {
            string result = string.Empty;

            GetDeliveryStatusJSON getDeliveryStatusJSON = new GetDeliveryStatusJSON();

            result = await GetDeliveryStatusString(paramGetDeliveryStatus);

            if (IsResultValid(result))
            {
                getDeliveryStatusJSON = JsonConvert.DeserializeObject<GetDeliveryStatusJSON>(result);
            }
            else
            {
                getDeliveryStatusJSON.ErrorsReturn = ReturnErrorJSON(result);
            }

            return getDeliveryStatusJSON;
        }

        /// <summary>
        /// 7.15 GET DELIVERY STATUS(WHEAT MOBILITY)
        /// </summary>
        /// <example>12.36 Get Delivery Status (Wheat Mobility)
        /// DeliverySearch/?type=BillofLading__c&value=BOLa3FS00000002YySMA1
        /// <returns>String query in JSON format</returns>
        public async Task<String> GetDeliveryStatusString(ParamGetDeliveryStatus paramGetDeliveryStatus)
        {
            string result = string.Empty;
            bool isConnect = false;
            string queryURL;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                queryURL = "DeliverySearch";
                //queryURL = "DeliverySearch/?type=BillofLading__c&value=BOLa3FS00000002Z1vMAE";
                //queryURL = "DeliverySearch/?type=BillofLading__c&value=BOLa3FS00000002bCMMAY";

                queryURL += paramGetDeliveryStatus.GetParamsJSON();

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Account Receive Ship "
        /// <summary>
        /// 7.17 GET Account Receive Ship (UnlistedTransactAccount)
        /// </summary>
        /// <example>12.38	Get Account Receive Ship (UnlistedTransactAccountUnlistedTransactAccount) (Wheat Mobility)
        /// UnlistedTransactAccount?userId=00530000007uHB7&onlyDealers=true
        /// <returns>Class GetAccountReceiveShipJSON</returns>
        public async Task<GetAccountReceiveShipJSON> GetAccountReceiveShip(ParamGetAccountReceiveShip paramGetAccountReceiveShip)
        {
            string result = string.Empty;

            GetAccountReceiveShipJSON getAccountReceiveShipJSON = new GetAccountReceiveShipJSON();

            result = await GetAccountReceiveShipString(paramGetAccountReceiveShip);

            if (IsResultValid(result))
            {
                getAccountReceiveShipJSON = JsonConvert.DeserializeObject<GetAccountReceiveShipJSON>(result);
            }
            else
            {
                getAccountReceiveShipJSON.ErrorsReturn = ReturnErrorJSON(result);
            }
            return getAccountReceiveShipJSON;
        }

        /// <summary>
        /// 7.17 GET Account Receive Ship (UnlistedTransitAccount)
        /// </summary>
        /// <example>12.38	Get Account Receive Ship (UnlistedTransactAccount) (Wheat Mobility)
        /// UnlistedTransactAccount?userId=00530000007uHB7&onlyDealers=true
        /// <returns>String query in JSON format</returns>
        public async Task<String> GetAccountReceiveShipString(ParamGetAccountReceiveShip paramGetAccountReceiveShip)
        {
            string result = string.Empty;
            bool isConnect = false;
            string queryURL;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                queryURL = "UnlistedTransactAccount";
                //queryURL = "UnlistedTransactAccount?userId=005S0000004P2C6&onlyDealers=true";
                //queryURL = "UnlistedTransactAccount?userId=00530000007uHB7&onlyDealers=true";

                queryURL += paramGetAccountReceiveShip.GetParamsJSON();

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Check Connection "
        /// <summary>
        /// 7.18 GET Check Connection
        /// </summary>
        /// <example>12.41	GET CHECK CONNECTION (WHEAT MOBILITY)
        /// CheckConnection
        /// <returns>Class GetCheckConnectionJSON</returns>
        public async Task<GetCheckConnectionJSON> GetCheckConnection()
        {
            string result = string.Empty;

            GetCheckConnectionJSON getCheckConnectionJSON = new GetCheckConnectionJSON();

            result = await GetCheckConnectionString();

            if (IsResultValid(result))
            {
                getCheckConnectionJSON = JsonConvert.DeserializeObject<GetCheckConnectionJSON>(result);
            }
            else
            {
                getCheckConnectionJSON.ErrorsReturn = ReturnErrorJSON(result);
            }

            return getCheckConnectionJSON;
        }

        /// <summary>
        /// 7.18 GET Check Connection
        /// </summary>
        /// <example>12.41	GET CHECK CONNECTION (WHEAT MOBILITY)
        /// CheckConnection
        /// <returns>String query in JSON format</returns>
        public async Task<String> GetCheckConnectionString()
        {
            string result = string.Empty;
            bool isConnect = false;
            string queryURL;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                queryURL = "CheckConnection";

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #region " Receiving Product "
        /// <summary>
        ///7.19 GET Receiving Product
        /// </summary>
        /// <example>12.39	GET Receiving Product (Purchase In) (Wheat Mobility) 
        /// CheckConnection
        /// <returns>Class GetReceivingProductJSON</returns>
        public async Task<GetReceivingProductJSON[]> GetReceivingProduct(ParamGetReceivingProduct paramGetReceivingProduct)
        {
            string result = string.Empty;

            GetReceivingProductJSON[] getReceivingProductJSON = new GetReceivingProductJSON[0];

            result = await GetReceivingProductString(paramGetReceivingProduct);

            if (IsResultValid(result))
            {
                getReceivingProductJSON = JsonConvert.DeserializeObject<GetReceivingProductJSON[]>(result);
            }
            else
            {
                getReceivingProductJSON[0].ErrorsReturn = ReturnErrorJSON(result);
            }

            return getReceivingProductJSON;
        }

        /// <summary>
        /// 7.19 GET Receiving Product
        /// </summary>
        /// <example>12.39	GET Receiving Product (Purchase In) (Wheat Mobility) 
        /// CheckConnection
        /// <returns>String query in JSON format</returns>
        public async Task<String> GetReceivingProductString(ParamGetReceivingProduct paramGetReceivingProduct)
        {
            string result = string.Empty;
            bool isConnect = false;
            string queryURL;

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                queryURL = "ReceivingProducts";
                //queryURL = "ReceivingProducts?shipFromAccountId=001S000000oJ2CeIAK&onlyCommercial=true";

                queryURL += paramGetReceivingProduct.GetParamsJSON();

                result = await GetData(UrllocationWheatMobile, queryURL);
            }

            return result;
        }
        #endregion

        #endregion

        #region " API POSTs "

        #region " WorkOrder Recieve "
        /// <summary>
        /// 7.11 - POST WorkOrder Recieve
        /// </summary>
        /// <example>12.33	POST Receiving WorkOrder  Details (Wheat Mobility)
        /// ReceivingWorkOrderDetails
        /// <returns>Class PostResponseJSON</returns>
        public async Task<PostPatchResponseJSON[]> PostWorkOrderRecieve(PostWorkOrderRecieveJSON postWorkOrderRecieveJSON)
        {
            string result = string.Empty;
            PostPatchResponseJSON[] postResponseJSON = new PostPatchResponseJSON[] { new PostPatchResponseJSON() };

            result = await PostWorkOrderRecieveString(postWorkOrderRecieveJSON);

            if (result != string.Empty)
            {
                postResponseJSON = JsonConvert.DeserializeObject<PostPatchResponseJSON[]>(result);
            }

            return postResponseJSON;
        }

        /// <summary>
        /// 7.11 - POST WorkOrder Recieve
        /// </summary>
        /// <example>12.33	POST Receiving WorkOrder  Details (Wheat Mobility)
        /// ReceivingWorkOrderDetails
        /// <returns>String query in JSON format</returns>
        public async Task<string> PostWorkOrderRecieveString(PostWorkOrderRecieveJSON postWorkOrderRecieveJSON)
        {
            bool isConnect = false;
            string result = string.Empty;
            const string queryURL = "ReceivingWorkOrderDetails";

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                result = await PostData(UrllocationWheatMobile, queryURL, postWorkOrderRecieveJSON);
            }

            return result;
        }
        #endregion

        #region " Receiving Delivery "
        /// <summary>
        /// 7.12  POST Receiving Delivery
        /// </summary>
        /// <example>12.31	POST Receiving Delivery Details (Wheat Mobility)
        /// ReceivingDeliveryDetails
        /// <returns>Class PostResponseJSON</returns>
        public async Task<PostPatchResponseJSON[]> PostReceivingDelivery(PostReceivingDeliveryJSON postReceivingDeliveryJSON)
        {
            string result = string.Empty;
            PostPatchResponseJSON[] postResponseJSON = new PostPatchResponseJSON[] { new PostPatchResponseJSON() };

            result = await PostReceivingDeliveryString(postReceivingDeliveryJSON);

            if (result != string.Empty)
            {
                postResponseJSON = JsonConvert.DeserializeObject<PostPatchResponseJSON[]>(result);
            }

            return postResponseJSON;
        }

        /// <summary>
        /// 7.12  POST Receiving Delivery
        /// </summary>
        /// <example>12.31	POST Receiving Delivery Details (Wheat Mobility)
        /// ReceivingDeliveryDetails
        /// <returns>String query in JSON format</returns>
        public async Task<string> PostReceivingDeliveryString(PostReceivingDeliveryJSON postReceivingDeliveryJSON)
        {
            bool isConnect = false;
            string result = string.Empty;
            const string queryURL = "ReceivingDeliveryDetails";

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                result = await PostData(UrllocationWheatMobile, queryURL, postReceivingDeliveryJSON);
            }

            return result;
        }
        #endregion

        #region " Shipment Delivery "
        /// <summary>
        /// 7.14 GET SHIPMENT DELIVERY(WHEAT MOBILITY)
        /// </summary>
        /// <example>
        /// ShippingDeliveryDetails
        /// <returns>Class PostResponseJSON</returns>
        public async Task<PostPatchResponseJSON[]> PostShipmentDelivery(PostShipmentDeliveryJSON postShipmentDeliveryJSON)
        {
            string result = string.Empty;
            PostPatchResponseJSON[] postResponseJSON = new PostPatchResponseJSON[] { new PostPatchResponseJSON() };

            result = await PostShipmentDeliveryString(postShipmentDeliveryJSON);

            if (result != string.Empty)
            {
                postResponseJSON = JsonConvert.DeserializeObject<PostPatchResponseJSON[]>(result);
            }

            return postResponseJSON;
        }

        /// <summary>
        /// 7.14 GET SHIPMENT DELIVERY(WHEAT MOBILITY)
        /// </summary>
        /// <example>
        /// ShippingDeliveryDetails
        /// <returns>String query in JSON format</returns>
        public async Task<string> PostShipmentDeliveryString(PostShipmentDeliveryJSON postShipmentDeliveryJSON)
        {
            bool isConnect = false;
            string result = string.Empty;
            const string queryURL = "ShippingDeliveryDetails";

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                result = await PostData(UrllocationWheatMobile, queryURL, postShipmentDeliveryJSON);
            }

            return result;
        }
        #endregion

        #region " Inventory Adjustment "
        /// <summary>
        /// 7.5  POST Inventory Adjustment
        /// </summary>
        /// <example>
        /// InventoryAdjustment
        /// <returns>Class PostResponseJSON</returns>
        public async Task<PostPatchResponseJSON[]> PostInventoryAdjustment(PostInventoryAdjustmentJSON postInventoryAdjustmentJSON)
        {
            string result = string.Empty;
            PostPatchResponseJSON[] postResponseJSON = new PostPatchResponseJSON[] { new PostPatchResponseJSON() };

            result = await PostInventoryAdjustmentString(postInventoryAdjustmentJSON);

            if (result != string.Empty)
            {
                postResponseJSON = JsonConvert.DeserializeObject<PostPatchResponseJSON[]>(result);
            }

            return postResponseJSON;
        }

        /// <summary>
        /// 7.5  POST Inventory Adjustment
        /// </summary>
        /// <example>
        /// InventoryAdjustment
        /// <returns>String query in JSON format</returns>
        public async Task<string> PostInventoryAdjustmentString(PostInventoryAdjustmentJSON postInventoryAdjustmentJSON)
        {
            bool isConnect = false;
            string result = string.Empty;
            const string queryURL = "InventoryAdjustment";

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                result = await PostData(UrllocationWheatMobile, queryURL, postInventoryAdjustmentJSON);
            }

            return result;
        }
        #endregion

        #region " Seed Count "
        /// <summary>
        /// 7.2  POST Seed Count
        /// </summary>
        /// <example>12.23	POST SEED COUNT(WHEAT MOBILITY)
        /// SeedsCount
        /// <returns>Class PostResponseJSON</returns>
        public async Task<PostPatchResponseJSON[]> PostSeedCount(PostSeedCountJSON postSeedCountJSON)
        {
            string result = string.Empty;
            PostPatchResponseJSON[] postResponseJSON = new PostPatchResponseJSON[] { new PostPatchResponseJSON() };

            result = await PostSeedCountString(postSeedCountJSON);

            if (result != string.Empty)
            {
                postResponseJSON = JsonConvert.DeserializeObject<PostPatchResponseJSON[]>(result);
            }

            return postResponseJSON;
        }

        /// <summary>
        /// 7.2  POST Seed Count
        /// </summary>
        /// <example>12.23	POST SEED COUNT(WHEAT MOBILITY)
        /// SeedsCount
        /// <returns>String query in JSON format</returns>
        public async Task<string> PostSeedCountString(PostSeedCountJSON postSeedCountJSON)
        {
            bool isConnect = false;
            string result = string.Empty;
            const string queryURL = "SeedsCount";

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                result = await PostData(UrllocationWheatMobile, queryURL, postSeedCountJSON);
            }

            return result;
        }
        #endregion

        #region " Receiving Unlisted "
        /// <summary>
        /// 7.16  POST Receiving Unlisted
        /// </summary>
        /// <example>12.37	POST Receiving Unlisted (Wheat Mobility)
        /// SeedsCount
        /// <returns>Class PostResponseJSON</returns>
        public async Task<PostPatchResponseJSON[]> PostReceivingUnlisted(PostReceivingUnlistedJSON postReceivingUnlistedJSON)
        {
            string result = string.Empty;
            PostPatchResponseJSON[] postResponseJSON = new PostPatchResponseJSON[] { new PostPatchResponseJSON() };

            result = await PostReceivingUnlistedString(postReceivingUnlistedJSON);

            if (result != string.Empty)
            {
                postResponseJSON[0].ErrorsReturn = JsonConvert.DeserializeObject<ErrorCodeJSON[]>(result);
            }

            return postResponseJSON;
        }

        /// <summary>
        /// 7.16  POST Receiving Unlisted
        /// </summary>
        /// <example>12.37	POST Receiving Unlisted (Wheat Mobility)
        /// SeedsCount
        /// <returns>String query in JSON format</returns>
        public async Task<string> PostReceivingUnlistedString(PostReceivingUnlistedJSON postReceivingUnlistedJSON)
        {
            bool isConnect = false;
            string result = string.Empty;
            const string queryURL = "ReceivingUnlisted";

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                result = await PostData(UrllocationWheatMobile, queryURL, postReceivingUnlistedJSON);
            }

            return result;
        }
        #endregion

        #region " Shipment Creation "
        /// <summary>
        /// 7.20  POSTSHIPMENT CREATION (WHEAT MOBILITY)
        /// </summary>
        /// <example>12.40	POSTSHIPMENT CREATION (WHEAT MOBILITY)
        /// SeedsCount
        /// <returns>Class PostResponseJSON</returns>
        public async Task<PostPatchResponseJSON[]> PostShipmentCreation(PostShipmentCreationJSON postShipmentCreationJSON)
        {
            string result = string.Empty;
            PostPatchResponseJSON[] postResponseJSON = new PostPatchResponseJSON[] { new PostPatchResponseJSON() };

            result = await PostShipmentCreationString(postShipmentCreationJSON);

            if (result != string.Empty)
            {
                postResponseJSON[0].ErrorsReturn = JsonConvert.DeserializeObject<ErrorCodeJSON[]>(result);
            }

            return postResponseJSON;
        }

        /// <summary>
        /// 7.20  POSTSHIPMENT CREATION (WHEAT MOBILITY)
        /// </summary>
        /// <example>12.40	POSTSHIPMENT CREATION (WHEAT MOBILITY)
        /// SeedsCount
        /// <returns>String query in JSON format</returns>
        public async Task<string> PostShipmentCreationString(PostShipmentCreationJSON postShipmentCreationJSON)
        {
            bool isConnect = false;
            string result = string.Empty;
            const string queryURL = "ShippingCreation";

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                result = await PostData(UrllocationWheatMobile, queryURL, postShipmentCreationJSON);
            }

            return result;
        }
        #endregion

        #endregion

        #region " API PATCHs "

        #region " Seed Count "
        /// <summary>
        /// 7.3   PATCH Seed Count
        /// </summary>
        /// <example>12.24	PATCH SEED COUNT(WHEAT MOBILITY)
        /// SeedsCount
        /// <returns>Class PostPatchResponseJSON</returns>
        public async Task<PostPatchResponseJSON[]> PatchSeedCount(PatchSeedCountJSON patchSeedCountJSON)
        {
            string result = string.Empty;
            PostPatchResponseJSON[] ResponseJSON = new PostPatchResponseJSON[] { new PostPatchResponseJSON() };

            result = await PatchSeedCountString(patchSeedCountJSON);

            if (result != string.Empty)
            {
                ResponseJSON = JsonConvert.DeserializeObject<PostPatchResponseJSON[]>(result);
            }

            return ResponseJSON;
        }

        /// <summary>
        /// 7.3   PATCH Seed Count
        /// </summary>
        /// <example>12.24	PATCH SEED COUNT(WHEAT MOBILITY)
        /// SeedsCount
        /// <returns>String query in JSON format</returns>
        public async Task<string> PatchSeedCountString(PatchSeedCountJSON patchSeedCountJSON)
        {
            bool isConnect = false;
            string result = string.Empty;
            const string queryURL = "SeedsCount";

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                result = await PatchData(UrllocationWheatMobile, queryURL, patchSeedCountJSON);
            }

            return result;
        }
        #endregion

        #region " Inventory Adjustment "
        /// <summary>
        /// 7.6  PATCH Inventory Adjustment
        /// </summary>
        /// <example>12.27	PATCH INVENTORY ADJUSTMENT (WHEAT MOBILITY)
        /// InventoryAdjustment
        /// <returns>Class PostResponseJSON</returns>
        public async Task<PostPatchResponseJSON[]> PatchInventoryAdjustment(PatchInventoryAdjustmentJSON patchInventoryAdjustmentJSON)
        {
            string result = string.Empty;
            PostPatchResponseJSON[] ResponseJSON = new PostPatchResponseJSON[] { new PostPatchResponseJSON() };

            result = await PatchInventoryAdjustmentString(patchInventoryAdjustmentJSON);

            if (result != string.Empty)
            {
                ResponseJSON = JsonConvert.DeserializeObject<PostPatchResponseJSON[]>(result);
            }

            return ResponseJSON;
        }

        /// <summary>
        /// 7.6  PATCH Inventory Adjustment
        /// </summary>
        /// <example>12.27	PATCH INVENTORY ADJUSTMENT (WHEAT MOBILITY)
        /// InventoryAdjustment
        /// <returns>String query in JSON format</returns>
        public async Task<string> PatchInventoryAdjustmentString(PatchInventoryAdjustmentJSON patchInventoryAdjustmentJSON)
        {
            bool isConnect = false;
            string result = string.Empty;
            const string queryURL = "InventoryAdjustment";

            if (!IsConnected)
            {
                isConnect = await Connect(new ConnectionInfos());
            }

            if (IsConnected == true)
            {
                result = await PatchData(UrllocationWheatMobile, queryURL, patchInventoryAdjustmentJSON);
            }

            return result;
        }
        #endregion

        #endregion
    }
}
