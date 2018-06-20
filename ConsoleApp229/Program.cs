using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp229
{
    public delegate void JudgeAdultHandler(object sender, PersonEventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The ManagedThreadId in Main method is {0}\n", Thread.CurrentThread.ManagedThreadId);

            Person p = new Person(31, "Floomberg");
            ParameterizedThreadStart pts = new ParameterizedThreadStart(DescPerson);
            Thread thread = new Thread(pts);
            thread.Start(p);
            Console.ReadLine();
        }

        static void DescPerson(object obj)
        {
            var person = obj as Person;
            if(person!=null)
            {
                Console.WriteLine(person.ToString());
            }
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

        protected void RaiseJudgeAdultEvent()
        {
            if(JudgeAdultEvent!=null)
            {
                JudgeAdultEvent(this, new PersonEventArgs(Age,DateTime.Now));
            }
        }

        internal void JudgePerson(object obj)
        {
            var p = obj as Person;
            if (p != null)
            {
                if(p.Age>18)
                {
                    RaiseJudgeAdultEvent();
                }
            }
        }

        public override string ToString()
        {
            return string.Format("Age:{0},Name:{1}\n", Age, Name);
        }
    }

    public class PersonEventArgs:EventArgs
    {
        public int PAge { get; set; }
        public DateTime Dt { get; set; }
        public PersonEventArgs(int pAge,DateTime dt)
        {
            PAge = pAge;
            Dt = dt;
        }        
    }
}
