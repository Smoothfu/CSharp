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
using System.IO;
using System.Text;
using System.Xaml;

namespace WpfApp21
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string xmlString = @"/WpfApp21;component/MainWindow.xaml";

            ConvertXmlStringToObjectGraph(xmlString);
        }

        public static object ConvertXmlStringToObjectGraph(string xmlString)
        {
            using (TextReader textReader = new StringReader(xmlString))
            using (XamlXmlReader reader = new XamlXmlReader(textReader, System.Windows.Markup.XamlReader.GetWpfSchemaContext()))
            using(XamlObjectWriter writer=new XamlObjectWriter(reader.SchemaContext))
            {
                //Simple node loop.
                while(reader.Read())
                {
                    writer.WriteNode(reader);
                }

                //When XamlObjectWriter is done,this is the root object insatnce.
                return writer.Result;
            }

        }
    }
}
