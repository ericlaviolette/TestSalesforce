using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using InventoryManager.LocalService;
using InventoryManager.Entity;
using InventoryManager.Entity.Params;
using InventoryManager.TestValuesJSON;
using System.Collections.Generic;

namespace TestSalesforce
{
    public partial class frmMain : Form
    {
        private bool passOneTime = false;
        private string lastQueryResult;

        private enum CurrentState { Connecting = 1,
                                    Connected,
                                    NotConnected

        }
        private CurrentState currentState;

        private List<string> userIDs = new List<string> { "005S0000004P2C6", "005S0000004vE0G" };

        private enum QueriesList {
            [Description("Get Inventory Trans DB - Main Dashborad")]
            GetInventoryTransDB = 1,
            [Description("7.1 - GET Seed Count")]
            GetSeedCount,
            [Description("7.2 - POST Seed Count")]
            PostSeedCount,
            [Description("7.3 - PATCH Seed Count")]
            PatchSeedCount,
            [Description("7.4 - GET Inventory Adjustment")]
            GetInventoryAdjustments,
            [Description("7.5 - POST Inventory Adjustment")]
            PostInventoryAdjustment,
            [Description("7.6 - PATCH Inventory Adjustment")]
            PatchInventoryAdjustment,
            [Description("7.7 - GET Attachment")]
            GetAttachment,
            [Description("7.8 - GET Inbound Deliveries (Receiving)")]
            GetInboundDeliveries,
            [Description("7.9 - POST Shipment Delivery")]
            PostShipmentDelivery,
            [Description("7.10 - Get Grower Output  PDF")]
            GetGrowerOutputPDF,
            [Description("7.11 - POST WorkOrder Recieve")]
            PostWorkOrderRecieve,
            [Description("7.12 - POST Receiving Delivery")]
            PostReceivingDelivery,
            [Description("7.13 - GET WAREHOUSE (WHEAT MOBILITY)")]
            GetWarehouse,
            [Description("7.14 - GET SHIPMENT DELIVERY (WHEAT MOBILITY)")]
            GetShipmentDelivery,
            [Description("7.15 - GET DELIVERY STATUS (WHEAT MOBILITY)")]
            GetDeliveryStatus,
            [Description("7.16 - POST Receiving Unlisted")]
            PostReceivingUnlisted,
            [Description("7.17 - GET Unlisted Transact Account (GET Account Receive Ship)")]
            GetAccountReceiveShip,
            [Description("7.18 - GET Check Connection")]
            GetCheckConnection,
            [Description("7.19 - GET Receiving Product")]
            GetReceivingProduct,
            [Description("7.20 - POSTSHIPMENT CREATION (WHEAT MOBILITY)")]
            PostShipmentCreation
        }

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            setTextSate("Auto Connecting to Salesforce...");
            currentState = CurrentState.Connecting;

            EnumUtil.EnumToListBox(default(QueriesList), lstQueries);

            lstUserId.DataSource = userIDs;
            lstUserId.SelectedIndex = 0;

            timerStateTime.Enabled = true;
            Connect();
        }

        private void btnConnectSF_Click(object sender, EventArgs e)
        {
            setTextSate("Connecting to Salesforce...");
            currentState = CurrentState.Connecting;

            Connect();
        }
               
        private void btnExecQuery_Click(object sender, EventArgs e)
        {
            if (lstQueries.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a query.", "TestSalesforce", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                Cursor = Cursors.WaitCursor;
                ExecGetData(GetSelectedIndex());
                Cursor = Cursors.Default;
            }
        }

        private QueriesList GetSelectedIndex()
        {
            int retIndex = 1;

            if (lstQueries.SelectedIndex == -1)
            {
                MessageBox.Show("Must select a query.", "TestSalesforce", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                retIndex = lstQueries.SelectedIndex + 1;
            }
            return (QueriesList)retIndex;
        }

        private async void Connect()
        {
            //ToDo: Here to Change connection
            //bool bRet = await Data.Instance.ConnectNew(new ConnectionInfos());
            bool bRet = await Data.Instance.Connect(new ConnectionInfos());
        }

        private async void ExecGetData(QueriesList query)
        {
            lastQueryResult = string.Empty;

            if (Data.Instance.IsConnected == true)
            {                
                switch (query)
                {
                    case QueriesList.GetInventoryTransDB:
                        ParamGetInboundDeliveries paramGetInboundDeliveriesDB = (ParamGetInboundDeliveries)GetParams(true, QueriesList.GetInboundDeliveries);
                        ParamGetInventoryAdjustment paramGetInventoryAdjustmentDB = (ParamGetInventoryAdjustment)GetParams(true, QueriesList.GetInventoryAdjustments);
                        ParamGetShipmentDelivery paramGetShipmentDeliveryDB = (ParamGetShipmentDelivery)GetParams(true, QueriesList.GetShipmentDelivery);
                        GetInventoryTransDBJSON getInventoryTransDBJSON = await Data.Instance.GetInventoryTransDB(paramGetInboundDeliveriesDB, 
                                                                                                                  paramGetInventoryAdjustmentDB,
                                                                                                                  paramGetShipmentDeliveryDB);
                        lastQueryResult = Data.Instance.LastResultString;
                        addTextLog(lastQueryResult);
                        getInventoryTransDBJSON = await Data.Instance.GetInventoryTransDB(paramGetInboundDeliveriesDB, 
                                                                                          paramGetInventoryAdjustmentDB,
                                                                                          paramGetShipmentDeliveryDB);
                        addTextLog(Environment.NewLine + new String('-', 240));
                        displayErrorIfAny(getInventoryTransDBJSON.GetInboundDeliveriesJSON.ErrorsReturn);
                        displayErrorIfAny(getInventoryTransDBJSON.GetInventoryAdjustmentsJSON);
                        displayErrorIfAny(getInventoryTransDBJSON.GetShipmentDeliveryJSON.ErrorsReturn);
                        addTextLog(Environment.NewLine + new String('-', 240));
                        break;

                    case QueriesList.GetInboundDeliveries:
                        setTextSate(Environment.NewLine + "Calling API GetInboundGetDeliveries...");
                        ParamGetInboundDeliveries paramGetInboundDeliveries = (ParamGetInboundDeliveries)GetParams();
                        lastQueryResult = await Data.Instance.GetInboundDeliveriesString(paramGetInboundDeliveries);
                        displayInfos();
                        GetInboundDeliveriesJSON getInboundDeliveriesJSON = await Data.Instance.GetInboundDeliveries(paramGetInboundDeliveries);
                        displayErrorIfAny(getInboundDeliveriesJSON.ErrorsReturn);
                        break;

                    case QueriesList.GetInventoryAdjustments:
                        setTextSate(Environment.NewLine + "Calling API GetInventoryAdjustments...");
                        ParamGetInventoryAdjustment paramGetInventoryAdjustment = (ParamGetInventoryAdjustment)GetParams();
                        lastQueryResult = await Data.Instance.GetInventoryAdjustmentString(paramGetInventoryAdjustment);
                        displayInfos();
                        GetInventoryAdjustmentsJSON[] getInventoryAdjustmentsJSON = await Data.Instance.GetInventoryAdjustment(paramGetInventoryAdjustment);
                        displayErrorIfAny(getInventoryAdjustmentsJSON);
                        break;

                    case QueriesList.GetShipmentDelivery:
                        setTextSate(Environment.NewLine + "Calling API GetShipmentDelivery...");
                        ParamGetShipmentDelivery paramGetShipmentDelivery = (ParamGetShipmentDelivery)GetParams(true, QueriesList.GetShipmentDelivery);
                        lastQueryResult = await Data.Instance.GetShipmentDeliveryString(paramGetShipmentDelivery);
                        displayInfos();
                        GetShipmentDeliveryJSON getShipmentDeliveryJSON = await Data.Instance.GetShipmentDelivery(paramGetShipmentDelivery);
                        displayErrorIfAny(getShipmentDeliveryJSON.ErrorsReturn);
                        break;

                    case QueriesList.GetAttachment:
                        setTextSate(Environment.NewLine + "Calling API GetAttachment...");
                        ParamGetAttachment paramGetAttachment = (ParamGetAttachment)GetParams(true, QueriesList.GetAttachment);
                        lastQueryResult = await Data.Instance.GetAttachmentString(paramGetAttachment);
                        displayInfos();
                        GetAttachmentJSON[] getAttachmentJSON = await Data.Instance.GetAttachment(paramGetAttachment);
                        displayErrorIfAny(getAttachmentJSON);
                        break;

                    case QueriesList.GetSeedCount:
                        setTextSate(Environment.NewLine + "Calling API GetSeedCount...");
                        ParamGetSeedCount paramGetSeedCount = (ParamGetSeedCount)GetParams();
                        lastQueryResult = await Data.Instance.GetSeedCountString(paramGetSeedCount);
                        displayInfos();
                        //GetSeedCountJSON[] getSeedCountJSON = await Data.Instance.GetSeedCount(paramGetSeedCount);
                        //displayErrorIfAny(getSeedCountJSON);
                        break;

                    case QueriesList.GetGrowerOutputPDF:
                        setTextSate(Environment.NewLine + "Calling API GetGrowerOutputPDF...");
                        ParamGetGrowerOutputPDF paramGetGrowerOutputPDF = (ParamGetGrowerOutputPDF)GetParams();
                        lastQueryResult = await Data.Instance.GetGrowerOutputPDFString(paramGetGrowerOutputPDF);
                        displayInfos();
                        GetGrowerOutputPDF[] getGrowerOutputPDF = await Data.Instance.GetGrowerOutputPDF(paramGetGrowerOutputPDF);
                        displayErrorIfAny(getGrowerOutputPDF);
                        break;

                    case QueriesList.GetWarehouse:
                        setTextSate(Environment.NewLine + "Calling API GetWarehouse...");
                        ParamGetWarehouse paramGetWarehouse = (ParamGetWarehouse)GetParams();
                        lastQueryResult = await Data.Instance.GetWarehouseString(paramGetWarehouse);
                        displayInfos();
                        GetWarehouseJSON getWarehouseJSON = await Data.Instance.GetWarehouse(paramGetWarehouse);
                        displayErrorIfAny(getWarehouseJSON.ErrorsReturn);
                        break;

                    case QueriesList.GetDeliveryStatus:
                        setTextSate(Environment.NewLine + "Calling API GetDeliveryStatus...");
                        ParamGetDeliveryStatus paramGetDeliveryStatus = (ParamGetDeliveryStatus)GetParams();
                        lastQueryResult = await Data.Instance.GetDeliveryStatusString(paramGetDeliveryStatus);
                        displayInfos();
                        GetDeliveryStatusJSON getDeliveryStatusJSON = await Data.Instance.GetDeliveryStatus(paramGetDeliveryStatus);
                        displayErrorIfAny(getDeliveryStatusJSON.ErrorsReturn);
                        break;

                    case QueriesList.GetAccountReceiveShip:
                        setTextSate(Environment.NewLine + "Calling API GetAccountReceiveShip...");
                        ParamGetAccountReceiveShip paramGetAccountReceiveShip = (ParamGetAccountReceiveShip)GetParams();
                        lastQueryResult = await Data.Instance.GetAccountReceiveShipString(paramGetAccountReceiveShip);
                        displayInfos();
                        GetAccountReceiveShipJSON getAccountReceiveShipJSON = await Data.Instance.GetAccountReceiveShip(paramGetAccountReceiveShip);
                        displayErrorIfAny(getAccountReceiveShipJSON.ErrorsReturn);
                        break;

                    case QueriesList.GetCheckConnection:
                        setTextSate(Environment.NewLine + "Calling API GetCheckConnection...");
                        // None parameter
                        lastQueryResult = await Data.Instance.GetCheckConnectionString();
                        displayInfos();
                        GetCheckConnectionJSON getCheckConnectionJSON = await Data.Instance.GetCheckConnection();
                        displayErrorIfAny(getCheckConnectionJSON.ErrorsReturn);
                        break;
                        
                    case QueriesList.PostWorkOrderRecieve:
                        setTextSate(Environment.NewLine + "Calling API PostWorkOrderRecieve...");
                        PostWorkOrderRecieveJSON postWorkOrderRecieveJSON = JsonConvert.DeserializeObject<PostWorkOrderRecieveJSON>(ValuesStringJSON.PostWorkOrderStringJSON);
                        lastQueryResult = await Data.Instance.PostWorkOrderRecieveString(postWorkOrderRecieveJSON);
                        displayInfos();
                        PostPatchResponseJSON[] postResponseWorkOrderRecieve = await Data.Instance.PostWorkOrderRecieve(postWorkOrderRecieveJSON);
                        displayErrorIfAny(postResponseWorkOrderRecieve, ValuesStringJSON.PostWorkOrderStringJSON);
                        break;

                    case QueriesList.PostReceivingDelivery:
                        setTextSate(Environment.NewLine + "Calling API PostReceivingDelivery...");
                        PostReceivingDeliveryJSON postReceivingDeliveryJSON = JsonConvert.DeserializeObject<PostReceivingDeliveryJSON>(ValuesStringJSON.PostReceivingDeliveryJSON);
                        lastQueryResult = await Data.Instance.PostReceivingDeliveryString(postReceivingDeliveryJSON);
                        displayInfos();
                        PostPatchResponseJSON[] postResponseReceivingDelivery = await Data.Instance.PostReceivingDelivery(postReceivingDeliveryJSON);
                        displayErrorIfAny(postResponseReceivingDelivery, ValuesStringJSON.PostReceivingDeliveryJSON);
                        break;

                    case QueriesList.PostShipmentDelivery:
                        setTextSate(Environment.NewLine + "Calling API PostShipmentDelivery...");
                        PostShipmentDeliveryJSON postShipmentDeliveryJSON = JsonConvert.DeserializeObject<PostShipmentDeliveryJSON>(ValuesStringJSON.PostShipmentDeliveryJSON);
                        lastQueryResult = await Data.Instance.PostShipmentDeliveryString(postShipmentDeliveryJSON);
                        displayInfos();
                        PostPatchResponseJSON[] postResponseShipmentDelivery = await Data.Instance.PostShipmentDelivery(postShipmentDeliveryJSON);
                        displayErrorIfAny(postResponseShipmentDelivery, ValuesStringJSON.PostShipmentDeliveryJSON);
                        break;

                    case QueriesList.PostInventoryAdjustment:
                        setTextSate(Environment.NewLine + "Calling API PostInventoryAdjustment...");
                        PostInventoryAdjustmentJSON postInventoryAdjustmentJSON = JsonConvert.DeserializeObject<PostInventoryAdjustmentJSON>(ValuesStringJSON.PostInventoryAdjustmentJSON);
                        lastQueryResult = await Data.Instance.PostInventoryAdjustmentString(postInventoryAdjustmentJSON);
                        displayInfos();
                        PostPatchResponseJSON[] postResponseInventoryAdjustment = await Data.Instance.PostInventoryAdjustment(postInventoryAdjustmentJSON);
                        displayErrorIfAny(postResponseInventoryAdjustment, ValuesStringJSON.PostInventoryAdjustmentJSON);
                        break;
                                            
                    case QueriesList.PostSeedCount:
                        setTextSate(Environment.NewLine + "Calling API PostSeedCount...");
                        PostSeedCountJSON postSeedCountJSON = JsonConvert.DeserializeObject<PostSeedCountJSON>(ValuesStringJSON.PostSeedCountJSON);
                        lastQueryResult = await Data.Instance.PostSeedCountString(postSeedCountJSON);
                        displayInfos();
                        PostPatchResponseJSON[] postResponseSeedCount = await Data.Instance.PostSeedCount(postSeedCountJSON);
                        displayErrorIfAny(postResponseSeedCount, ValuesStringJSON.PostSeedCountJSON);
                        break;

                    case QueriesList.PatchSeedCount:
                        setTextSate(Environment.NewLine + "Calling API PatchSeedCount...");
                        PatchSeedCountJSON patchSeedCountJSON = JsonConvert.DeserializeObject<PatchSeedCountJSON>(ValuesStringJSON.PatchSeedCountJSON);
                        lastQueryResult = await Data.Instance.PatchSeedCountString(patchSeedCountJSON);
                        displayInfos();
                        PostPatchResponseJSON[] ResponseSeedCount = await Data.Instance.PatchSeedCount(patchSeedCountJSON);
                        displayErrorIfAny(ResponseSeedCount, ValuesStringJSON.PatchSeedCountJSON);
                        break;

                    case QueriesList.PatchInventoryAdjustment:
                        setTextSate(Environment.NewLine + "Calling API PatchInventoryAdjustment...");
                        PatchInventoryAdjustmentJSON patchInventoryAdjustment = JsonConvert.DeserializeObject<PatchInventoryAdjustmentJSON>(ValuesStringJSON.PatchInventoryAdjustment);
                        lastQueryResult = await Data.Instance.PatchInventoryAdjustmentString(patchInventoryAdjustment);
                        displayInfos();
                        PostPatchResponseJSON[] ResponseInventoryAdjustment = await Data.Instance.PatchInventoryAdjustment(patchInventoryAdjustment);
                        displayErrorIfAny(ResponseInventoryAdjustment, ValuesStringJSON.PatchInventoryAdjustment);
                        break;

                    case QueriesList.PostReceivingUnlisted:
                        setTextSate(Environment.NewLine + "Calling API PostReceivingUnlisted...");
                        PostReceivingUnlistedJSON postReceivingUnlistedJSON = JsonConvert.DeserializeObject<PostReceivingUnlistedJSON>(ValuesStringJSON.PostReceivingUnlistedJSON);
                        lastQueryResult = await Data.Instance.PostReceivingUnlistedString(postReceivingUnlistedJSON);
                        displayInfos();
                        PostPatchResponseJSON[] postResponseReceivingUnlisted = await Data.Instance.PostReceivingUnlisted(postReceivingUnlistedJSON);
                        displayErrorIfAny(postResponseReceivingUnlisted, ValuesStringJSON.PostReceivingUnlistedJSON);
                        break;

                    case QueriesList.GetReceivingProduct:
                        setTextSate(Environment.NewLine + "Calling API GetReceivingProduct...");
                        ParamGetReceivingProduct paramGetReceivingProduct = (ParamGetReceivingProduct)GetParams();
                        lastQueryResult = await Data.Instance.GetReceivingProductString(paramGetReceivingProduct);
                        displayInfos();
                        GetReceivingProductJSON[] getReceivingProductJSON = await Data.Instance.GetReceivingProduct(paramGetReceivingProduct);
                        displayErrorIfAny(getReceivingProductJSON);
                        break;

                    case QueriesList.PostShipmentCreation:
                        setTextSate(Environment.NewLine + "Calling API PostShipmentCreation...");
                        PostShipmentCreationJSON postShipmentCreationJSON = JsonConvert.DeserializeObject<PostShipmentCreationJSON>(ValuesStringJSON.PostShipmentCreationJSON);
                        lastQueryResult = await Data.Instance.PostShipmentCreationString(postShipmentCreationJSON);
                        displayInfos();
                        PostPatchResponseJSON[] postResponseShipmentCreation = await Data.Instance.PostShipmentCreation(postShipmentCreationJSON);
                        displayErrorIfAny(postResponseShipmentCreation, ValuesStringJSON.PostShipmentCreationJSON);
                        break;

                    default:
                        break;
                }
                                
            }
            else
            {
                displayNotConnected();
            }
        }

        private void displayErrorIfAny(EntityModelErrorBase[] entityModelErrorBase, string dataSent = "")
        {
            foreach (EntityModelErrorBase entityModel in entityModelErrorBase)
            {
                if (entityModel != null)
                {
                    if (entityModel.HasError())
                    {
                        displayErrorIfAny(entityModel.ErrorsReturn, dataSent);
                    }
                }
            }
        }

        private void displayErrorIfAny(ErrorCodeJSON[] errorCodeJSON, string dataSent = "")
        {
            if (errorCodeJSON != null)
            {
                if (errorCodeJSON.Length > 0)
                {
                    foreach (ErrorCodeJSON errorCode in errorCodeJSON)
                    {
                        if (errorCode.HasError())
                        {
                            addTextLog("Returned Class Errors :");

                            addTextLog("errorCode : " + errorCode.errorCode + ", message : " + errorCode.message);

                            if (errorCode.recordIDS != null)
                            {
                                if (errorCode.recordIDS.Count > 0)
                                {
                                    addTextLog("Returned recordIDs :" + Environment.NewLine);

                                    foreach (string recordId in errorCode.recordIDS)
                                    {
                                        addTextLog("recordId : " + recordId + Environment.NewLine);
                                    }
                                }
                            }
                        }
                    }

                    if (dataSent != String.Empty)
                    {
                        addTextLog("DataSent : " + dataSent);
                    }
                }
            }
        }

        private void displayInfos()
        {
            addTextLog(Data.Instance.LastQueryURL);
            displayLastResult();
        }

        private void displayLastResult()
        {
            if (lastQueryResult != string.Empty)
            {
                addTextLog("Return values from API call: " + Environment.NewLine + lastQueryResult);
                addTextLog(Environment.NewLine + new String('-', 240));
            }
        }

        private void setTextSate(string text)
        {
            toolStripStatusMain.Text = text;
            addTextLog(text);
        }

        private void addTextLog(string text)
        {
            txtInfos.AppendText(text + Environment.NewLine);
            txtInfos.SelectionStart = txtInfos.Text.Length - 1;
            txtInfos.SelectionLength = 0;
            txtInfos.Refresh();
        }

        private void displayNotConnected()
        {
            MessageBox.Show("Not connected.", "Test Salesforce", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }              
                
        private void timerStateTime_Tick(object sender, EventArgs e)
        {
            toolStripStatusTime.Text = DateTime.Now.ToShortTimeString();

            setState();
        }
             
        private void setState()
        {            
            switch (currentState)
            {
                case CurrentState.Connecting:
                    if (Data.Instance.IsConnected == true)
                    {
                        currentState = CurrentState.Connected;
                        setTextSate("Connected to Salesforce.");
                    }
                    else
                    {
                        if (Data.Instance.LastResultString != String.Empty)
                        {
                            currentState = CurrentState.NotConnected;
                            setTextSate("Not connected.");
                            addTextLog(Data.Instance.LastResultString + Environment.NewLine + new String('-', 240));
                        }
                    }
                    break;

                case CurrentState.Connected:
                    if (passOneTime == false)
                    {
                        passOneTime = true;
                        addTextLog(Data.Instance.LastResultString + Environment.NewLine + new String('-', 240));
                    }
                    break;

                case CurrentState.NotConnected:
                    break;

                default:
                    break;
            }
        }

        private void btnCopyLastResultOnly_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lastQueryResult, TextDataFormat.Text);
        }

        private void btnOpenJSONViewer_Click(object sender, EventArgs e)
        {
            StartURL("http://jsonviewer.stack.hu");
        }

        private void btnOpenJSONConvertToCSharp_Click(object sender, EventArgs e)
        {
            StartURL("http://jsonutils.com/");
        }

        private void btnOpenGoogleSearch_Click(object sender, EventArgs e)
        {
            StartURL("https://www.google.ca/?ion=1&espv=2#q=c%23");
        }

        private void StartURL(string URL)
        {
            System.Diagnostics.Process.Start(URL);
        }

        private void btnAddDoubleQuotes_Click(object sender, EventArgs e)
        {
            txtQuotes.Text = txtQuotes.Text.Replace(@"""", @"""""");
        }

        private void btnRemoveDoubleQuotes_Click(object sender, EventArgs e)
        {
            txtQuotes.Text = txtQuotes.Text.Replace(@"""""", @"""" );
        }

        private void btnTestParams_Click(object sender, EventArgs e)
        {
            if (Data.Instance.IsConnected == true)
            {
                QueriesList query = GetSelectedIndex();
                string returnStr = string.Empty;
                bool isValidParams = false;

                switch (query)
                {
                    case QueriesList.GetSeedCount:
                        ParamGetSeedCount paramGetSeedCount = (ParamGetSeedCount)GetParams();
                        isValidParams = paramGetSeedCount.IsValidParams();
                        returnStr = paramGetSeedCount.GetParamsJSON();
                        break;

                    case QueriesList.GetInboundDeliveries:
                        ParamGetInboundDeliveries paramGetInboundDeliveries = (ParamGetInboundDeliveries)GetParams();
                        isValidParams = paramGetInboundDeliveries.IsValidParams();
                        returnStr = paramGetInboundDeliveries.GetParamsJSON();
                        break;

                    default:
                        break;
                }
                MessageBox.Show(returnStr + Environment.NewLine + "ValidParams = " + isValidParams.ToString());
            }
        }

        private ParamsBase GetParams(bool forceQuery = false, QueriesList wantedQuery = QueriesList.GetInventoryAdjustments)
        {
            QueriesList query;
            bool addUserId = false;

            if (forceQuery==false)
            {
                query = GetSelectedIndex();
            }
            else
            {
                query = wantedQuery;
            }

            ParamsBase returnParam = null;

            switch (query)
            {
                case QueriesList.GetSeedCount:
                    ParamGetSeedCount paramGetSeedCount = new ParamGetSeedCount();
                    returnParam = paramGetSeedCount;
                    break;

                case QueriesList.GetInboundDeliveries:
                    ParamGetInboundDeliveries paramGetInboundDeliveries = new ParamGetInboundDeliveries();
                    returnParam = paramGetInboundDeliveries;
                    break;

                case QueriesList.GetInventoryAdjustments:
                    ParamGetInventoryAdjustment paramGetInventoryAdjustment = new ParamGetInventoryAdjustment();
                    returnParam = paramGetInventoryAdjustment;
                    break;

                case QueriesList.GetShipmentDelivery:
                    ParamGetShipmentDelivery paramGetShipmentDelivery = new ParamGetShipmentDelivery();
                    returnParam = paramGetShipmentDelivery;
                    break;

                case QueriesList.GetAttachment:
                    ParamGetAttachment paramGetAttachment = new ParamGetAttachment();
                    paramGetAttachment.attachmentId = "00PS00000020fcz";
                    returnParam = paramGetAttachment;
                    break;

                case QueriesList.GetGrowerOutputPDF:
                    ParamGetGrowerOutputPDF paramGetGrowerOutputPDF = new ParamGetGrowerOutputPDF();
                    paramGetGrowerOutputPDF.deliveryId = "a5FS0000000139x";
                    returnParam = paramGetGrowerOutputPDF;
                    break;

                case QueriesList.GetWarehouse:
                    ParamGetWarehouse paramGetWarehouse = new ParamGetWarehouse();
                    returnParam = paramGetWarehouse;
                    break;

                case QueriesList.GetDeliveryStatus:
                    ParamGetDeliveryStatus paramGetDeliveryStatus = new ParamGetDeliveryStatus();
                    paramGetDeliveryStatus.type = "BillofLading__c";
                    paramGetDeliveryStatus.value = "BOLa3FS00000002Z1vMAE";
                    returnParam = paramGetDeliveryStatus;
                    break;

                case QueriesList.GetAccountReceiveShip:
                    ParamGetAccountReceiveShip paramGetAccountReceiveShip = new ParamGetAccountReceiveShip();
                    returnParam = paramGetAccountReceiveShip;
                    break;

                case QueriesList.GetReceivingProduct:
                    ParamGetReceivingProduct paramGetReceivingProduct = new ParamGetReceivingProduct();
                    addUserId = false;
                    paramGetReceivingProduct.shipFromAccountId = lstUserId.SelectedItem.ToString();
                    returnParam = paramGetReceivingProduct;
                    break;

                default:
                    break;
            }

            if (addUserId)
            {
                returnParam.userId = lstUserId.SelectedItem.ToString();
            }
                
            return returnParam;
        }
    }
}
