using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public static class DateTimeFormatExtension
    {
        public static DateTime FormatDatetime(this string str)
        {
            try
            {
                var data = str.Split(' ');
                return DateTime.ParseExact(data[0], "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                //return DateTime.ParseExact(str, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return DateTime.Now;
        }
    }
}
