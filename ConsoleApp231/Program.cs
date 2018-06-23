using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ConsoleApp231
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fi = new FileInfo(@".\myTxt.txt");
            using (StreamWriter sw = fi.AppendText())
            {
                string msg = "This world is beautiful!";
                sw.WriteLine(msg);
            }

            using (StreamReader sr = fi.OpenText())
            {
                string str = sr.ReadToEnd();
                Console.WriteLine(str);
            }

            Console.ReadLine();
        }

        public static void DescPerson(object obj)
        {
            var p = obj as Person;
            if(p!=null)
            {
                Console.WriteLine("Age:{0}\n", p.Age);
            }
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age)
        {
            Age = age;
        }
        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }

        public static Person operator +(Person a,Person b)
        {
            return new Person(a.Age + b.Age);
        }
    }
}
