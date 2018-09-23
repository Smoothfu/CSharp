using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp27
{
    class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Job { get; set; }
        public string Hobby { get; set; }

        public override string ToString()
        {
            string msg = string.Format("Id:{0},Name:{1},Age:{2},Job:{3},Hobby:{4}\n",Id,Name,Age,Job,Hobby);
            return msg;
        }
    }
}
