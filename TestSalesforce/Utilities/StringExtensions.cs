using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManager
{
    public static class StringExtensions
    {
        public static bool Contains(this string source, string checkWith, StringComparison comp)
        {
            //return source.IndexOf(checkWith, comp) >= 0;
            if (string.IsNullOrEmpty(source) || source == "(Null)")
            {
                source = string.Empty;
            }

            return source.ToLower().Contains(checkWith.ToLower());
        }
    }
}
