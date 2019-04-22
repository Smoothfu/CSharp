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

namespace WpfApp32
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> usersList = new ObservableCollection<User>();        
        public MainWindow()
        {
            InitializeComponent(); 

            for(int i=0;i<10;i++)
            {
                usersList.Add(new User()
                {
                    Name = "Fred" + i,
                    Id = i
                });
            }

            lbUsers.ItemsSource = usersList;
        }        

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            usersList.Add(new User() { Name = "New User" + Guid.NewGuid().ToString(), Id = rnd.Next(10, 100)  });
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if(lbUsers.SelectedItem!=null)
            {
                var selectedUser = lbUsers.SelectedItem as User;
                if(selectedUser!=null)
                {
                    selectedUser.Name = "Random Name"+Guid.NewGuid().ToString();
                }
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItem != null)
            {
                var deleteUser = lbUsers.SelectedItem as User;
                if (deleteUser != null)
                {
                    usersList.Remove(deleteUser);
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
                return this.name;
            }
            set
            {
                if(this.name!=value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        private int id;
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                if(this.id!=value)
                {
                    this.id = value;
                    NotifyPropertyChanged("Id");
                }
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
