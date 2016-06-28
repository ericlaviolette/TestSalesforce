using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

namespace TestSalesforce
{
    public static class EnumUtil
    {
        public static string ToDescription<TEnum>(this TEnum EnumValue) where TEnum : struct
        {
            return EnumUtil.GetEnumDescription((Enum)(object)((TEnum)EnumValue));
        }

        public static string GetEnumDescription<T>(this T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                                          typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        public static void EnumToListBox(Enum EnumType, ListBox lstEnums)
        {
            List<string> enumDesc = new List<String>();

            foreach (Enum enumValue in Enum.GetValues(EnumType.GetType()))
            {
                enumDesc.Add(GetEnumDescription(enumValue));
            }
            lstEnums.DataSource = enumDesc;
        }
                      
    }
}
