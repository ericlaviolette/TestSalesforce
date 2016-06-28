using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManager.Entity;
using InventoryManager;

namespace InventoryManager.Entity
{
    public class ViewModelInventoryTransDB
    {
        private string displayStatus;
        private string status;
        private string createdDate;
        private string buttonName;
        private string inventoryType;

        public string InventoryType
        {
            get
            {
                return inventoryType;
            }
            set
            {
                inventoryType = value;
            }
        }
        public string CreatedDate
        {
            get
            {
                return createdDate;
            }
            set
            {
                try
                {
                    var temp = value.FormatDatetime();

                    if (temp != null)
                    {
                        createdDate = temp.ToString("MM/dd/yyyy");
                    }
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                }
            }
        }
        public string TransactionId { get; set; }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;

                if (Status == "Received" || Status == "Confirmed" || Status == "Completed" || Status == "Complete")
                {
                    displayStatus = "Completed";
                    buttonName = "\uF00C Details";
                    IsVisible = true;
                }
                else if (Status == "Open" || Status == "Goods Issued" || Status == "Unsubmitted" || Status == "Pending" || Status == "In Progress")
                {
                    displayStatus = "Pending";
                    buttonName = "\uF044 Edit";
                    IsVisible = true;
                }
                else if (Status == "Submitted with Errors")
                {
                    displayStatus = "Errors";
                    buttonName = "Errors";
                    IsVisible = true;
                }
                else
                {
                    //displayStatus = "No Status Mapped";
                    IsVisible = false;
                }
            }
        }
        public string CustomerName { get; set; }
        //public bool isEdit { get; set; }
        public bool IsVisible { get; set; }
        public string DisplayStatus
        {
            get
            {
                return displayStatus;
            }

        }

        public string ButtonName
        {
            get
            {
                return buttonName;
            }
        }

        public string CommandParam
        {
            get
            {
                return inventoryType + "," + displayStatus + "," + TransactionId;
            }
        }

        //viewModelInventoryTransDB.InventoryType = "Receiving"; //Constants.TransactionType.Receiving;
        //viewModelInventoryTransDB.CreatedDate = getInboundDeliveriesRAW.objShipmentWrapper.lstShipment[0].shipmentFieldMaps.deliveryDate;
        //viewModelInventoryTransDB.CustomerName = getInboundDeliveriesRAW.objShipmentWrapper.lstShipment[0].shipmentFieldMaps.fromAccountName;
        //viewModelInventoryTransDB.Status = getInboundDeliveriesRAW.objShipmentWrapper.lstShipment[0].shipmentFieldMaps.deliveryStatus;
        //viewModelInventoryTransDB.TransactionId = getInboundDeliveriesRAW.objShipmentWrapper.lstShipment[0].shipmentFieldMaps.bolNumber;


    }
}
