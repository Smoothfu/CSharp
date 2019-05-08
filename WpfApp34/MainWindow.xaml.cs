using System;
using System.Collections.Generic;
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

namespace WpfApp34
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            InitPersonList();          
        }

        private void InitPersonList()
        {
            for(int i=0;i<100;i++)
            {
                PersonList.Add(new Person(i, "Fred" + i));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private List<Person> personList = new List<Person>();
        public List<Person> PersonList
        {
            get
            {
                return personList;
            }
            set
            {
                if(value!=personList)
                {
                    personList = value;
                    NotifyPropertyChanged("PersonList");
                }
            }
        }
    }

    public class Person:INotifyPropertyChanged
    {

        public Person(int pId,string pName)
        {
            this.Id = pId;
            this.Name = pName;
        }
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
                    NotifyPropertyChanged("Name");
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
                if(value!=id)
                {
                    id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
