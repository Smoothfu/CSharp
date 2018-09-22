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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private string setTextValue;
        public string SetTextValue
        {
            get
            {
                 
                setTextValue = "This is the new value";
                return setTextValue;
            }
            set
            {
                setTextValue = value;
            }
        }

        private string labelContent;
        public string LabelContent
        {
            get
            {
                labelContent = "this is label content!";
                return labelContent;
            }
            set
            {
                labelContent = value;
            }
        }

        //Change the foreground to blue when the mouse enters the button.
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if(btn!=null)
            {
                btn.Foreground = Brushes.Blue;
            }
        }

        //Restore the foreground to black when the mouse exit the button.
        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            Button leaveBth = sender as Button;
            if(leaveBth!=null)
            {
                leaveBth.Foreground = Brushes.Black;
            }
        }

        public static void SetFontSize(DependencyObject element,double value)
        {
            element.SetValue(TextElement.FontSizeProperty, value);
        }

        public static double GetFontSize(DependencyObject element)
        {
            return (double)element.GetValue(TextElement.FontSizeProperty);
        }
    }
}
