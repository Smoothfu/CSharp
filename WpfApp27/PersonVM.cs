using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp27
{
    class PersonVM
    {
        private List<Person> mPersonList;
        public List<Person> PersonList
        {
            get
            {
                return mPersonList;
            }
            set
            {
                mPersonList = value;
            }
        }
        public PersonVM()
        {
            mPersonList = new List<Person>();
            for(int i=0;i<100000001;i++)
            {
                mPersonList.Add(new Person()
                {
                    Id = i                    
                });
            }
        }
    }
}
