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
using WpfApp32.Models;

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
            this.DataContext = this;
        }

        private void InitChildren()
        {
            List<Person> persons = new List<Person>();
            Person p1 = new Person() { Name = "Fred1", Age = 42 };
            Person p2 = new Person() { Name = "Fred2", Age = 10 };

            Person child1 = new Person() { Name = "Fred3", Age = 8 };
            p1.Children.Add(child1);
            p2.Children.Add(child1);

            p2.Children.Add(new Person() { Name = "Fred4", Age = 6 });
            Person p3 = new Person() { Name = "Fred5", Age = 4 };

            persons.Add(p1);
            persons.Add(p2);
            persons.Add(p3);

            p2.IsExpanded = true;
            p2.IsSelected = true;
            //trvPersons.ItemsSource = persons;
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
