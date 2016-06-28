using System.Collections.Generic;
using InventoryManager.Utilities;
using System.Reflection;
using Newtonsoft.Json;
using System;

namespace InventoryManager.Entity.Params
{
    public abstract class ParamsBase
    {
        public ParamsBase()
        {
            // ToDo: Change userId with real userId. You can override the Method IsValidParams() to avoid IsValidParams.
            userId = "005S0000004P2C6";    // use that user for lstShipment
            //userId = "005S0000004vE0G";  // use that user for lstHeaderWO
            //userId = UserInfos.sfdc_community_id;  // userId from logon user
        }

        /// <summary>
        /// Use it in the first line of your function, example:  return base.GetParamsJSON(this); 
        /// Add your additionnal required fields.
        /// </summary>
        /// <param name="oDerivedClass">use keyword 'this'</param>
        /// <returns></returns>
        public string GetParamsJSON(ParamsBase oDerivedClass)
        {
            //// SerializeObject
            //return JsonConvert.SerializeObject(this);
            string retParamsJSON = string.Empty;
            string paramValue;

            IEnumerable<PropertyInfo> propertiesInfos = oDerivedClass.GetType().GetRuntimeProperties();

            foreach (PropertyInfo propInfo in propertiesInfos)
            {
                paramValue = GetValueOrEmptyString(propInfo.GetValue(this));

                if (paramValue != string.Empty)
                {
                    if (retParamsJSON == string.Empty)
                    {
                        retParamsJSON = "?";
                    }
                    else
                    {
                        retParamsJSON += "&";
                    }

                    retParamsJSON += propInfo.Name + "=" + paramValue;
                }

            }

            return retParamsJSON;
        }

        private string GetValueOrEmptyString(object objProp)
        {
            if (objProp == null)
            {
                return string.Empty;
            }
            else
            {
                return (string)objProp;
            }
        }

        /// <summary>
        /// UserId almost always required. You can overwrite or erase this value.
        /// </summary>
        public string userId { get; set; }

        public bool IsNullOrStringEmpty(object param)
        {
            if (param == null || (string)param == string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Overwrite it to erase userId validation like this [ public new bool  IsValidParams() ] and/or add your required fields. 
        /// Or use it in the first line of your function, example:  return base.IsValidParams();
        /// </summary>
        /// <returns></returns>
        public bool IsValidParams()
        {
            if (IsNullOrStringEmpty(userId))
            {
                return false;
            }
            return true;
        }
    }
}
