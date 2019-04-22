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
            InitFamilies();
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

            trvFamilies.ItemsSource = families;
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
