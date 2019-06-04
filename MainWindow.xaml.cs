using System;
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
            usersList.Add(new User() { Name = "Fred Fu" });
            usersList.Add(new User() { Name = "Cloud Lee" });
            lbUsers.ItemsSource = usersList;
            this.DataContext = this;
        }

        

        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            usersList.Add(new User() { Name = "New User"+Guid.NewGuid() });
        }

        private void BtnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if(lbUsers.SelectedItem!=null)
            {
                (lbUsers.SelectedItem as User).Name = "Changed Name"+Guid.NewGuid();
            }
        }

        private void BtnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                usersList.Remove(lbUsers.SelectedItem as User);
            }
        }

        private void InsertUser_Click(object sender, RoutedEventArgs e)
        {             
            usersList.Add(new User() { Name = "Added User" + Guid.NewGuid() });
            var lastIndex = usersList.Count;
            usersList.Insert(lastIndex, new User() { Name = "Inserted User" + Guid.NewGuid() });
        }

        private void ClearUsers_Click(object sender, RoutedEventArgs e)
        {
            usersList.Clear();
        }

        private void RemoveUser_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedUser!=null)
            {
                usersList.Remove(selectedUser);
            }                      
        }

        private void RemoveItem_Click(object sender, RoutedEventArgs e)
        {
            if(SelectedUser!=null)
            {
                var selectedIndex = usersList.IndexOf(SelectedUser);
                if(selectedIndex!=-1)
                {
                    usersList.RemoveAt(selectedIndex);
                }
            }
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
}
