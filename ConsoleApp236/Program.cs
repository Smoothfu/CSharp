using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp236
{
    public delegate void JudgeAdultHandler(object sender, PersonEventArgs e);
    public delegate void AddHandler(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            AddHandler addHandler = new AddHandler(AddMethod);
            addHandler(10, 10);
             
            Console.ReadLine();
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
