using SalesModule.ViewModel;
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
using System.Windows.Shapes;

namespace SalesModule.Views
{
    /// <summary>
    /// Interaction logic for AddEditWindow.xaml
    /// </summary>
    public partial class AddEditView : Window
    {
        public AddEditView()
        {
            InitializeComponent();
            SalesViewModel addEditVM = SalesViewModel.GetSalesViewModelInstance();
            if(addEditVM.CloseAction==null)
            {
                addEditVM.CloseAction = new Action(() =>
                  {
                      MessageBoxResult mbr = MessageBox.Show("Are you sure to cancel?", "Warning", MessageBoxButton.YesNo,
                          MessageBoxImage.Asterisk);
                      if(mbr==MessageBoxResult.Yes)
                      {
                          this.Close();
                      }
                  });
            }
            this.DataContext = addEditVM;
        }
    }
}
