using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp32.Models;

namespace WpfApp32.Models
{
    class Person:TreeViewItemBase
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public ObservableCollection<Person> Children { get; set; }
        public Person()
        {
            this.Children = new ObservableCollection<Person>();
        }
    }
}
