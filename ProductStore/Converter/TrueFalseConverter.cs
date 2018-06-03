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
                return TrueFalseEnum.Unknow;
            }

            bool IsTrue;
            if(Boolean.TryParse(value.ToString(),out IsTrue))
            {
                if(IsTrue)
                {
                    return TrueFalseEnum.True;
                }
                else
                {
                    return TrueFalseEnum.False;
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
