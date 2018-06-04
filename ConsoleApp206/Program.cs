using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp206
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentEqualityComparer stuComparer = new StudentEqualityComparer();
            List<Student> universtyStudent = new List<Student>()
            {
                new Student(1,"Fred"),
                new Student(2,"Floomberg"),
                new Student(3,"Frankly")
            };

            List<Student> colleagueStudent = new List<Student>()
            {
                new Student(1,"Fred"),
                new Student(2,"Floomberg"),
                new Student(3,"Bloomberg")
            };

            var commonList = from u in universtyStudent
                             from c in colleagueStudent
                             where u.SId == c.SId && u.SName == c.SName
                             select u;
            foreach(var c in commonList)
            {
                Console.WriteLine(c);
            }

            var temp = commonList;
            Console.ReadLine();
        }
    }

    public class Student
    {
        public int SId { get; set; }
        public string SName { get; set; }

        public Student(int id,string name)
        {
            SId = id;
            SName = name;
        }

        public override bool Equals(object obj)
        {
            var otherStu = obj as Student;
            if(otherStu!=null)
            {
                return this.SId.Equals(otherStu.SId) && this.SName.Equals(otherStu.SName);
            }
            return false;            
        }

        public override string ToString()
        {
            return string.Format("StuId:{0},StuName:{1}\n", SId, SName);
        }

        public bool Equals(Student x, Student y)
        { 
            if(x!=null && y!=null)
            {
                return x.SId.Equals(y.SId) && x.SName.Equals(y.SName);
            }
            return false;
        }

        public int GetHashCode(Student obj)
        {
            return base.GetHashCode();
        }
    }

    public class StudentEqualityComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
          return  x.Equals(y);
        }

        public int GetHashCode(Student obj)
        {
            return obj.GetHashCode();
        }
    }

}
