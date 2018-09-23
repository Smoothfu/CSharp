using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp27
{
    class PersonVM
    {
        private List<Person> mPersonList=new List<Person>();
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
            for(int i=0;i<100000;i++)
            {
                mPersonList.Add(new Person()
                {
                    Id = i,
                    Name = "Fred" + i,
                    Age = 30 + i,
                    Job = "CS" + i,
                    Hobby = "Business" + i
                });
            }
        }
    }
}
