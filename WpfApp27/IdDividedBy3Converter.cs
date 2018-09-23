using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp27
{
    public class IdDividedBy3Converter : IValueConverter
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
                if(intObj%3==0)
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
