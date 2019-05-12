using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApp39.Converter
{
    class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rowsIndex;
            if (value != null && int.TryParse(value.ToString(), out rowsIndex))
            {
                switch (rowsIndex % 5)
                {
                    case 0:
                        return new SolidColorBrush(Colors.Yellow);
                        
                    case 1:
                        return new SolidColorBrush(Colors.Purple);
                         
                    case 2:
                        return new SolidColorBrush(Colors.Red);
                         
                    case 3:
                        return new SolidColorBrush(Colors.Green);
                        
                    case 4:
                        return new SolidColorBrush(Colors.Blue);
                         
                    default:
                        return new SolidColorBrush(Colors.Yellow);
                }
            }

            return new SolidColorBrush(Colors.Purple);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
