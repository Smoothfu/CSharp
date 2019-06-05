using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApp44.Converters
{
    public class SelectedDataRowViewToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isSelected = false;
            if(value!=null)
            {
                var selectedDataRowView = value as DataRowView;
                if(selectedDataRowView!=null)
                {
                    isSelected = true;
                }
            }
            return isSelected;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
