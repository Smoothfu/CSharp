using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp230
{
    public delegate void JudgeAdultHandler(object sender, PersonEventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Main ManagedThreadId is {0}", Thread.CurrentThread.ManagedThreadId);
            Thread thread = new Thread(() =>
              {
                  Person p = new Person(31, "Floomberg");
                  p.JudgeAdultEvent += P_JudgeAdultEvent;
                  p.JudgeAdult(p);

              });

            thread.Start();
            Console.ReadLine();
        }

        private static void P_JudgeAdultEvent(object sender, PersonEventArgs e)
        {
            Console.WriteLine("The event binding responding method's managedthreadid is {0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("This is an adult person,and his age is {0},its {1} now", e.Age, e.DT);
        }

        static void DescPerson(object obj)
        {
            var p = obj as Person;
            if(p!=null)
            {
                Console.WriteLine(p.ToString());
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

        public override string ToString()
        {
           
            return string.Format("Age:{0},Name:{1}\n", Age, Name);
        }

        public virtual void RaiseJudgeAdultEvent()
        {
            if(JudgeAdultEvent!=null)
            {
                JudgeAdultEvent(this, new PersonEventArgs(Age, DateTime.Now));
            }
        }

        public void JudgeAdult(Person p)
        {
            Console.WriteLine("The  JudgeAdult managedThreadId in Person class is {0}\n", Thread.CurrentThread.ManagedThreadId);
            if (p.Age>18)
            {
                RaiseJudgeAdultEvent();
            }
        }
    }

    public class PersonEventArgs:EventArgs
    {
        public int Age { get; set; }
        public DateTime DT { get; set; }
        public PersonEventArgs(int age,DateTime dt)
        {
            Age = age;
            DT = dt;
        }
    }
}
