using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp238
{
    public delegate void JudgeAdultHandler(object sender, PersonEventArgs e);
    class Program
    {
        
        static void Main(string[] args)
        {
            Person p = new Person(31, "Fred");
            p.JudgeAdultEvent += P_JudgeAdultEvent;
            p.JudgeAdult(p);
            
            Console.ReadLine();
        }

        private static void P_JudgeAdultEvent(object sender, PersonEventArgs e)
        {
            Console.WriteLine("This is an adult,its age is :{0},time is :{1}\n", e.Age, e.Dt);
        }

        static void DescPerson(object obj)
        {
            var person = obj as Person;
            Console.WriteLine(person.ToString());

        }

    }

    public class Person
    {
        public   event JudgeAdultHandler JudgeAdultEvent;
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }

        public  void JudgeAdult(Person p)
        {
            if(p.Age>18)
            {
                OnJudgeAdult();
            }
        }

        public virtual void OnJudgeAdult()
        {
            if(JudgeAdultEvent!=null)
            {
                JudgeAdultEvent(this, new PersonEventArgs(Age, DateTime.Now));
            }
        }

        public override string ToString()
        {
            return string.Format("Name:{0},Age:{1}\n", Name, Age);
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
