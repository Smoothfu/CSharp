using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WpfApp43.GetDBTableWCFService;
using System.Data;

namespace WpfApp43
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        private ObservableCollection<User> usersList = new ObservableCollection<User>();
        private User selectedUser;
        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                if(value!=selectedUser)
                {
                    selectedUser = value;
                    OnPropertyChanged("SelectedUser");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            GetDBTableWCFService.GetDBTableClient serviceInstance = new GetDBTableClient();
            DataTable dt = serviceInstance.GetDataTable();
            dg.ItemsSource = dt.DefaultView;
            this.DataContext = this;
        }        

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            usersList.Add(new User() { Name = "New User"+Guid.NewGuid() });
        }       
    }
    public class User:INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if(value!=name)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }

    public class UsersCollection : IEnumerable<UsersCollection>
    {
        public IEnumerator<UsersCollection> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
