using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp228
{
    public delegate void JudgeAdultHandler(object sender,PersonEventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(31, "Floomberg");
            p.JudgeAdultEvent += P_JudgeAdultEvent;
            p.JudgeAdult(p);
            Console.ReadLine();
        }

        private static void P_JudgeAdultEvent(object sender, PersonEventArgs e)
        {
            Console.WriteLine("The current person is adult and his age is " + e.EAge);
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

        protected virtual void OnJudgeAdultEvent()
        {
            if(JudgeAdultEvent!=null)
            {
                JudgeAdultEvent(this, new PersonEventArgs(Age));
            }
        }
        public override string ToString()
        {
            return string.Format("Age:{0},Name:{1}\n", Age, Name);
        }

        public void JudgeAdult(Person p)
        {
            if(p.Age>18)
            {
                OnJudgeAdultEvent();
            }
        }
    }

    public class PersonEventArgs:EventArgs
    {
        public int EAge { get; set; }
        public PersonEventArgs(int eAge)
        {
            EAge = eAge;
        }
    }
}
