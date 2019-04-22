using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp32.Models
{
    class Family
    {
        public string Name { get; set; }
        public ObservableCollection<FamilyMember> Members { get; set; }

        public Family()
        {
            Members = new ObservableCollection<FamilyMember>();
        }
    }
}
