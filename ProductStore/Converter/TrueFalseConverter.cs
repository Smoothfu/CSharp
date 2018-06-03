using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductStore.CommonClass;
using System.Windows.Data;
using System.Globalization;

namespace ProductStore.Converter
{
    public class TrueFalseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value==null)
            {
                return -1;
            }

            if(value is TrueFalseEnum)
            {
               if((TrueFalseEnum)value==TrueFalseEnum.True)
                {
                    return 1;
                }
               else
                 if((TrueFalseEnum)value==TrueFalseEnum.False)
                {
                    return 0;
                }

               else if((TrueFalseEnum)value==TrueFalseEnum.Unknow)
                {
                    return -1;
                }
            }            
            
            return -1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
