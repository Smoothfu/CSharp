using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Globalization;

namespace WpfApp27
{
    class IdColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool result = false;
            if(value==null)
            {
                return result;
            }

            int intObj;
            if(int.TryParse(value.ToString(),out intObj))
            {
                if (intObj % 2 == 1)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
            }   
            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
