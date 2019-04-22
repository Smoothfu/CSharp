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
            InitMenuItems();
        }

        private void InitMenuItems()
        {
            WpfApp32.Models.MenuItem root = new WpfApp32.Models.MenuItem()
            {
                Title = "Menu"
            };
            WpfApp32.Models.MenuItem childItem1 = new Models.MenuItem()
            {
                Title = "Child item #1"
            };
            childItem1.Items.Add(new Models.MenuItem()
            {
                Title = "Child item #1.1"
            });
            childItem1.Items.Add(new Models.MenuItem()
            {
                Title = "Child item #1.2"
            });

            root.Items.Add(childItem1);
            root.Items.Add(new Models.MenuItem()
            {
                Title = "Child item #2"
            });
            trvMenu.Items.Add(root);
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
