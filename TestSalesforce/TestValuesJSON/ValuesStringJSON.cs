using System.Collections.Generic;
using InventoryManager.Utilities;

namespace InventoryManager.TestValuesJSON
{
    public static class ValuesStringJSON
    {
        public const string PostWorkOrderStringJSON = @"
                                        {
	                                        ""objWorkOrderParent"": {
                                                ""warehouseSFDCId"": ""a4DS0000000010j"",
		                                        ""warehouseAccountSFDCId"": ""001S000000oBGkU"",
		                                        ""workOrderType"": ""Wheat Work Order Bagging"",
		                                        ""parentWorkOrderSFDCId"": ""a4NS0000000GEL0"",
		                                        ""note"":""this is a test note"",
		                                        ""lstWorkOrderChild"":[{
			                                        ""workOrderSFDCId"": ""a4NS0000000GEL5"",
			                                        ""productSFDCId"": ""a2SS0000000HjX8"",
			                                        ""recievedQunatity"": ""10"",
			                                        ""prefUOM"": ""LB"",
			                                        ""workOrderNumber"": ""WO -20160510-001378""
                                                }],
		                                        ""lstAttachment"": [
                                                {
		                                          ""fileName"": ""test1"",
		                                          ""base64Data"": ""MTIzNDU2Nzg5MCBIZWxsbw =="",
		                                          ""contentType"": ""text/plain""
                                                }]	
	                                        }
                                        }";

        public const string PostReceivingDeliveryJSON = @"
                                        {
                                            ""objShipment"":{
                                                ""note"": ""Delivery Attachment Demo"",
                                                ""lstAttachment"": [
                                                {
                                                    ""fileName"": ""test1"",
                                                    ""base64Data"": ""MTIzNDU2Nzg5MCBIZWxsbw=="",
                                                    ""contentType"": ""text/plain""
                                                }
                                                ],
                                                ""lstDelivery"": [
                                                {
                                                    ""deliverySFDCID"": ""a5FS000000010vN"",
                                                    ""transactionSource"": ""WheatMobile"",
                                        ""warehouseSFDCId"":""a4DS0000000010j"",

                                                    ""lstReceiptQueue"": [
                                                    {
             
                                                        ""receiptQueueSFDCId"": ""a2zS00000008hZH"",
                                                        ""warehouseSFDCId"": ""a4DS0000000010j"",
                                                        ""productSFDCId"": ""a2SS0000000HijN"",
                                                        ""shippedQuantity"": ""5"",
                                                        ""receivedQuantity"": ""5"",
                                                        ""productLotSFDCId"": ""a2XS00000006Oc9""
                                                    },
                                                    {
             
                                                        ""receiptQueueSFDCId"": ""a2zS00000008hZG"",
                                                        ""warehouseSFDCId"": ""a4DS0000000010j"",
                                                        ""productSFDCId"": ""a2SS0000000HijN"",
                                                        ""shippedQuantity"": ""20"",
                                                        ""receivedQuantity"": ""20"",
                                                        ""productLotSFDCId"": ""a2XS00000006Oc4""
                                                    }
                                                    ]
                                                }
                                                ]
                                            }
                                        }";

        public const string PostShipmentDeliveryJSON = @"
                                        {
                                            ""objShipment"":{
                                            ""note"":""test Note"",
                                            ""lstAttachment"":[{
                                                                ""fileName"":""test1"",
                                                                ""base64Data"":""MTIzNDU2Nzg5MCBIZWxsbw=="",
                                                                ""contentType"":""text/plain""
                                                                            }],
                                            ""lstDelivery"":[
                                                            {
                                                            ""deliverySFDCID"" : ""a5FS00000006FqgMAE"",
                                                            ""grossWeight"" : ""5"",
                                                            ""tareWeight"" : ""10"",
                                                            ""weightsKeyed"" : ""Yes"",
                                                            ""driver"" : ""testDriver"",
                                                            ""licensePlate"": ""test Licence Plate"",
                                                            ""noOfAxle"": ""9"",
                                                             ""bolNumber"": ""testBolNumber"",
                                                            ""lstInvReserve"":[{
                                                                                ""deliveryLineId"":""a24S0000000HaE3IAK"",
                                                                                ""productSFDCID"":""a2SS0000000HlSgMAK"",
                                                                                ""toWarehouseAccountID"":""001S000000oBGk5IAG""
                                                                            }]
                                                            }
                                            ]}
                                        }";

        public const string PostInventoryAdjustmentJSON = @"
                                        {
                                            ""productInventoryAdjustmentLots"": [{ 
	                                        ""warehouseSFDCID"": ""a4DS0000000010j"", 
	                                        ""locationSFDCID"": ""a4nS00000004FtYIAU"", 
	                                        ""productLotSFDCID"": ""a2XS00000006Oc9MAE"", 
	                                        ""adjustedQuantity"": ""250"", 
	                                        ""adjustmentType"": ""Increase Quantity"", 
	                                        ""transactionDate"": ""2016-03-29"",
	                                        ""adjustmentReason"": ""Clean Out"", 
	                                        ""productSFDCID"": ""a2SS0000000HijNMAS"", 
	                                        ""note"": ""this is a test note test 1 and test2"", 
	                                        ""lstAttachment"": [{  
		                                        ""fileName"": ""test1"",  
		                                        ""base64Data"": ""MTIzNDU2Nzg5MCBIZWxsbw=="",  
		                                        ""contentType"": ""text/plain"" 
	                                        }, {
		                                        ""fileName"": ""test2"",
		                                        ""base64Data"": ""MTIzNDU2Nzg5MCBIZWxsbw=="",
		                                        ""contentType"": ""text/plain""
	                                        }]
                                        }]
                                        }";

        public const string PostSeedCountJSON = @"
                                            {
                                               ""workOrderObj"" : { 
                                                ""workOrderId"":""a4NS0000000GDl7"",
                                                ""averageSeedCount"":""12"", 
                                                ""lstSeedCountSample"":  [
                                                     {
	                                                ""seedCountSampleId"" : null, 
	                                                ""seedCount"" : ""120"", 
	                                                ""seedCountDateTime"" : ""2016-03-21 12:18:29"" 
                                                    }] 
                                                }
                                            }";

        public const string PatchSeedCountJSON = @"
                                    {
                                        ""productLots"":[
                                        {
                                        ""seedCount"" : ""70"",  
                                        ""seedCountDateTime"" : ""2016-03-21 10:18:29"", 
                                        ""productLotSFDCID"" : ""a2XS00000006Prd"", 
                                        ""forceUpdate"" : false 
                                        }
                                        ]
                                        }";

        public const string PatchInventoryAdjustment = @"
                                    {
	                                    ""lstInvAdjustment"": [{
		                                    ""warehouseSFDCID"": ""a4Dn000000051svEAA"",
		                                    ""locationSFDCID"": ""a4nn00000000FuyAAE"",
		                                    ""productLotSFDCID"": ""a2Xn000000027K2EAI"",
		                                    ""adjustedQuantity"": ""2.0"",
		                                    ""preferredUOM"": ""BAG"",
		                                    ""adjustmentType"": ""Increase Quantity"",
		                                    ""transactionDate"": ""2016-05-17"",
		                                    ""adjustmentReason"": ""Clean Out"",
		                                    ""productSFDCID"": ""a2S30000000rVLOEA2"",
		                                    ""InventoryAdjustmentSFDCId"": ""a5yn00000000WoxAAE"",
		                                    ""note"": ""this is a test note test 1"",
                                                    ""transactionSource"":""Wheat Mobile"",  
		                                    ""lstattachment"": [{
			                                    ""fileName"": ""adjustedSlip.txt"",
			                                    ""base64Data"": ""MTIzNDU2Nzg5MCBIZWxsbw=="",
			                                    ""contentType"": ""text/plain""
		                                    }]
	                                    }]
                                    }";

        public const string PostReceivingUnlistedJSON = @"
                                    {
	                                    ""requestSalesorderWrapper"": {
		
		                                    ""shipFromAccountId"": ""001S000000oBGkUIAW"",
		
		                                    ""shipToAccId"": ""001S000000oBGk5IAG"",
		                                    ""vComments"": ""TEST COMMENTS"",
		
		                                    ""bolNumber"": ""527"",
		                                    ""lstAttachment"": [
                                            {
                                              ""fileName"": ""test1"",
                                              ""base64Data"": ""MTIzNDU2Nzg5MCBIZWxsbw=="",
                                              ""contentType"": ""text/plain""
                                            }
		                                    ],


		                                    ""productLines"": [
		                                    {
			                                    ""productId"": ""a2SS0000000HijIMAS"",
			                                    ""uom"": ""BAG"",
			                                    ""productDetailLines"": [
				                                    {
					
					                                    ""lotNumber"": ""1"",
					                                    ""shippedQty"": 1,
					                                    ""receivedQty"": 1

				                                    }
			                                    ]

		                                    },
		                                    {
			                                    ""productId"": ""a2SS0000000HijSMAS"",
			                                    ""uom"": ""BAG"",
			                                    ""productDetailLines"": [
				                                    {
					
					                                    ""lotNumber"": ""1"",
					                                    ""shippedQty"": 1,
					                                    ""receivedQty"": 1

				                                    },
				                                    {
					
					                                    ""lotNumber"": ""2"",
					                                    ""shippedQty"": 1,
					                                    ""receivedQty"": 1

				                                    }
			                                    ]

		                                    }]
	                                    }
                                    }";

        public const string PostShipmentCreationJSON = @"
                                                {
                                                    ""objSOWrapper"": {
                                                    ""isRetailOrder"":false,
                                                                ""shipFromAccountId"":""001S000000oBGk6"",
                                                                ""shipToAccountId"":""001S000000oBGk5"",
                                                                ""shipFromWarehouseId"":""a4DS0000000010j"",
                                                                ""shipToWarehouseId"":""a4DS000000001VG"",
                                                    ""salesOrderComments"": ""test comments"",
                                                    ""bolNumber"": ""1234559"",
                                                    ""deliverySFDCID"": """",
                                                    ""deliveryNote"": ""test Note"",
                                                    ""grossWeight"": ""5"",
                                                        ""tareWeight"": ""10"",
                                                        ""weightsKeyed"": ""Yes"",
                                                        ""driver"": ""testDriver"",
                                                        ""licensePlate"": ""test Licence Plate"",
                                                        ""noOfAxle"": ""9"",
                                                    ""lstProducts"": [
                                                        {
                                                        ""deliveryLineId"": """",
                                                        ""unitOfMeasure"": ""SSU"",
                                                        ""productSFDCID"": ""a2SS0000000HijS"",
                                                        ""unitPrice"": ""55.0"",
                                                        ""orderQty"": ""2.0"",
                                                        ""lotSFDCID"": ""a2XS0000000QyLl"",
                                                        ""toWarehouseAccountId"": ""001S000000oBGk5"",
                                                                                ""toWarehouseId"": ""a4DS000000001VG"",
                                                        ""comments"": ""test comments""
                                                        },
                                                                    {
                                                        ""deliveryLineId"": """",
                                                        ""unitOfMeasure"": ""SSU"",
                                                        ""productSFDCID"": ""a2SS0000003oVXt"",
                                                        ""unitPrice"": ""55.0"",
                                                        ""orderQty"": ""2.0"",
                                                        ""lotSFDCID"": ""a2XS0000000QyQq"",
                                                        ""toWarehouseAccountId"": ""001S000000oBGk5"",
                                                                                ""toWarehouseId"": ""a4DS000000001VG"",
                                                        ""comments"": ""test comments""
                                                        }
                                                    ],
                                                    ""lstAttachment"": [
                                                    {
                                                        ""fileName"": ""test1"",
                                                        ""base64Data"": ""MTIzNDU2Nzg5MCBIZWxsbw=="",
                                                        ""contentType"": ""text/plain""
                                                    }
                                                    ]
                                                    }
                                                }";

    }
}
