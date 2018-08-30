using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp257
{
    interface IA
    {
        void AddMethod(int x, int y);
    }

    interface IB
    {
        void AddMethod(int x, int y);
    }

    class AddClass : IA, IB
    {
        void IA.AddMethod(int x, int y)
        {
            Console.WriteLine("In IA:{0}+{1}={2}\n", x, y, x + y);
        }

        void IB.AddMethod(int x, int y)
        {
            Console.WriteLine("In IB:{0}+{1}={2}\n", x, y, x + y);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student(1, "Fred");
            Student stu2 = stu.ShallowCopy();
            Console.WriteLine("The original values:\n");
            Console.WriteLine("stu:" + stu);
            Console.WriteLine("stu2: " + stu2);

            stu.StuId = 2;
            stu.StuName = "Floomberg";
            Console.WriteLine("The changed values:\n");
            Console.WriteLine("stu: " + stu);
            Console.WriteLine("stu2: " + stu2);
           
           
            Console.ReadLine();
        }

        static void DisplayValues(Person p)
        {
            Console.WriteLine("Name:{0:s},Age:{1:d}", p.Name, p.Age);
            Console.WriteLine("Value:{0:d}", p.IdInfo.IdNumber);
        }
    }

    public class IdInfo
    {
        public int IdNumber;
        public IdInfo(int idNumber)
        {
            this.IdNumber = idNumber;
        }
    }

    public class Person
    {
        public int Age;
        public string Name;
        public IdInfo IdInfo;


        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        public Person DeepCopy()
        {
            Person other = (Person)this.MemberwiseClone();
            other.IdInfo = new IdInfo(IdInfo.IdNumber);
            other.Name = string.Copy(Name);
            return other;
        }
    }

    public class Student
    {
        public int StuId { get; set; }
        public string StuName { get; set; }
        public Student(int id,string name)
        {
            this.StuId = id;
            this.StuName = name;
        }

        public   Student ShallowCopy()
        {
            return (Student)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return string.Format("Id:{0},Name:{1}\n", StuId, StuName);
        }
    }
}
