using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp32
{
    class NumbertoEvenOddConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int intValue;
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                if(Int32.TryParse(value.ToString(),out intValue))
                {
                    if (intValue % 2 == 0)
                    {
                        return "Even";
                    }
                    else
                    {
                        return "Odd";
                    }
                }               
            }           
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(value.ToString()))
            {
                string str = value.ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    if(str.ToUpper().Equals("EVEN"))
                    {
                        return 0;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            return -1;           
        }
    }
}
