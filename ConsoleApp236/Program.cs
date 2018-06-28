using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.IO;

namespace ConsoleApp236
{
    public delegate void JudgeAdultHandler(object sender, PersonEventArgs e);
    public delegate void AddHandler(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(".");
            DirectoryInfo parentDir = dir.Parent.Parent.Parent;
            FileInfo[] allFis=parentDir.GetFiles("*", SearchOption.AllDirectories);
            if (allFis != null && allFis.Any())
            {
                Parallel.ForEach(allFis, x =>
                {
                    Console.WriteLine(x.FullName);
                });
            }


            Console.WriteLine("\n\nThere are totally {0} files in {1}\n", allFis.Count(), parentDir.FullName);
            Console.ReadLine();
        }

        static void DescPerson(object p)
        {
            var person = p as Person;
            if(person!=null)
            {
                Console.WriteLine(person.ToString());
            }
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}", x, y, x + y);
        }

        private static void P_JudgeAdultEvent(object sender, PersonEventArgs e)
        {
            Console.WriteLine("It's age is {0},and time is {1}\n", e.Age, e.Dt);
        }
    }

    public class Person
    {
        public event JudgeAdultHandler JudgeAdultEvent;
        public int Age { get; set; }
        public string Name { get; set; }
        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }

        public void JudgePersonAdult(Person p)
        {
            if(p.Age>18)
            {
                OnJudgeAdultEvent();
            }
        }

        protected void OnJudgeAdultEvent()
        {
            if(JudgeAdultEvent!=null)
            {
                JudgeAdultEvent(this, new PersonEventArgs(Age, DateTime.Now));
            }
        }

        public override string ToString()
        {
            return string.Format("This person's age :{0},Name:{1}\n", Age, Name);
        }
    }

    public class PersonEventArgs:EventArgs
    {
        public int Age { get; set; }
        public DateTime Dt { get; set; }

        public PersonEventArgs(int age,DateTime dt)
        {
            Age = age;
            Dt = dt;
        }
    }
}
