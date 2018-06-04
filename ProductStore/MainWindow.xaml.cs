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
using ProductStore.ViewModel;
using ProductStore.Model;

namespace ProductStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static ProductVM _ProVM;
        public MainWindow()
        {
            InitializeComponent();
            _ProVM = new ProductVM();
            this.DataContext = _ProVM;
        }

        private void dg_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            _ProVM.ProductCollection_CollectionChanged(sender, e);

            var changedProduct = sender as TProduct;
            if(changedProduct!=null)
            {
                var changedIndex = _ProVM.ProductCollection.IndexOf(changedProduct);
                if(changedIndex>-1)
                {

                }
            }
        }
    }
}
