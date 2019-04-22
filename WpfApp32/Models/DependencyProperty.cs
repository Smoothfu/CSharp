using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp32.Models
{
    class DependencyProperty2:DependencyObject
    {
        public static readonly DependencyProperty CurrentTimeProperty = DependencyProperty.Register
            ("CurrentTime", typeof(DateTime), typeof(MainWindow),  
            new FrameworkPropertyMetadata(DateTime.Now),new ValidateValueCallback(BooleanValidateValueCallback));

        private static bool BooleanValidateValueCallback(object value)
        {
            MessageBox.Show(DateTime.Now.ToString());
            return true;
        }
    }
}
