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
using WPFPrism.ViewModel;

namespace WPFPrism.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            LoginViewModel loginVM = new LoginViewModel();
            if(loginVM.CloseAction==null)
            {
                loginVM.CloseAction = new Action(() =>
                  {
                      this.Close();
                  });
            }
            this.DataContext = loginVM;
        }
    }
}
