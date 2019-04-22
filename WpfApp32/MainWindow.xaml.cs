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
            InitChildren();
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
            trvPersons.ItemsSource = persons;
        }

        private void InitFamilies()
        {
            List<Family> families = new List<Family>();
            Family fam1 = new Family() { Name = "Fred's Tycoon Family" };
            fam1.Members.Add(new FamilyMember() { Name = "Fred I", Age = 42 });
            fam1.Members.Add(new FamilyMember() { Name = "Fred II", Age = 10 });
            fam1.Members.Add(new FamilyMember() { Name = "Fred III", Age = 8 });
            families.Add(fam1);

            Family fam2 = new Family() { Name = "Fu's Family" };
            fam2.Members.Add(new FamilyMember() { Name = "Fu I", Age = 38 });
            fam2.Members.Add(new FamilyMember() { Name = "Fu II", Age = 15 });
            families.Add(fam2);

            
        }

        private void btnSelectNext_Click(object sender, RoutedEventArgs e)
        {
            if(trvPersons.SelectedItem!=null)
            {
                var list = (trvPersons.ItemsSource as List<Person>);
                int curIndex = list.IndexOf(trvPersons.SelectedItem as Person);
                if(curIndex>=0)
                {
                    curIndex++;
                }
                if(curIndex>=list.Count)
                {
                    curIndex = 0;
                }
                if(curIndex>=0)
                {
                    list[curIndex].IsSelected = true;
                }
            }
        }

        private void btnToggleExpansion_Click(object sender, RoutedEventArgs e)
        {
            if(trvPersons.SelectedItem!=null)
            {
                (trvPersons.SelectedItem as Person).IsExpanded = !(trvPersons.SelectedItem as Person).IsExpanded;
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
