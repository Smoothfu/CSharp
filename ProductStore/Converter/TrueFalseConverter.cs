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

            if(value is Boolean)
            {
               if((bool)value==true)
                {
                    return TrueFalseEnum.True;
                }
               else
                 if((bool)value==false)
                {
                    return TrueFalseEnum.False;
                }

               else 
                {
                    return TrueFalseEnum.Unknow;
                }
            }            
            
            return TrueFalseEnum.Unknow;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
