using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBDll.Dll
{
    public class DTConvert
    {
        public static List<T> ConvertDTToList<T>(DataTable dt)
        {
            List<T> dataList = new List<T>();
            foreach(DataRow dr in dt.Rows)
            {
                T obj = ConvertDataRowToT<T>(dr);
                dataList.Add(obj);
            }
            return dataList;
        }

        public static T ConvertDataRowToT<T>(DataRow dr)
        {
            Type typeOfT = typeof(T);
            T obj = Activator.CreateInstance<T>();
            var properties = typeOfT.GetProperties();
            for(int i=0;i<properties.Length;i++)
            {
                var prop = properties[i];
                var itemValue = dr.ItemArray[i];
                if(itemValue!=DBNull.Value)
                {
                    prop.SetValue(obj, itemValue, null);
                }
            }
            return obj;
        }
    }
}
