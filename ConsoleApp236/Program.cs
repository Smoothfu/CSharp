using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp236
{
    public delegate void JudgeAdultHandler(object sender, PersonEventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(31, "Fred");
            p.JudgeAdultEvent += P_JudgeAdultEvent;
            p.JudgePersonAdult(p);
            Console.ReadLine();
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
