using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp24
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty SetTextProperty = DependencyProperty.Register("SetText",typeof(string), typeof(UserControl1),
            new PropertyMetadata("", new PropertyChangedCallback(OnSetTextChanged)));

        private static void OnSetTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl1 uc = d as UserControl1;
            if(uc!=null)
            {
                uc.OnSetTextChanged(e);
            }
        }

        public string SetText
        {
            get
            {
                return (string)GetValue(SetTextProperty);
            }
            set
            {
                SetValue(SetTextProperty, value);
            }
        }

        //private static void OnSetTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    UserControl1 userControl = d as UserControl1;
        //    if(userControl!=null)
        //    {
        //        userControl.OnSetTextChanged(e);
        //    }
        //}

        private void OnSetTextChanged(DependencyPropertyChangedEventArgs e)
        {
            tb.Text = e.NewValue.ToString();
        }
    }
}
