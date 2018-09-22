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
                var metaData = UserControl1.SetTextProperty.GetMetadata(typeof(MainWindow));                
                setTextValue = metaData.DefaultValue.ToString();
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
        

    }
}
