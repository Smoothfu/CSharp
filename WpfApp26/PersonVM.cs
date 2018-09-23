using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp26
{
    class PersonVM
    {
        public PersonVM()
        {
            for (int i = 0; i < 100000; i++)
            {
                personList.Add(new Person()
                {
                    Id = i,
                    Name = "Fred" + i,
                    Age = 31 + i,
                    Job = "CTO" + i,
                    Hobby = "Business" + i
                });
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
                personList = value;
            }
        }
    }
}
