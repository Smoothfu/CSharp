using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp228
{
    public delegate void JudgeAdultHandler(object sender,PersonEventArgs e);
    public delegate void JudgeRichHandler(object sender, RichPersonEventArgs e);
    class Program
    {
        static int x = 2354345, y = 245643674;
        static void Main(string[] args)
        {
            Person p = new Person(31, 1323452562465);
            ThreadStart ts = new ThreadStart(Add);
            Thread thread = new Thread(ts);
            thread.Start();
            
            Console.ReadLine();
        }


        static void Add()
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }
        static void DescPerson(object obj)
        {
            var person = obj as Person;
            if(person!=null)
            {
                Console.WriteLine(person.ToString());
            }
        }

        private static void P_JudgeRichEvent(object sender, RichPersonEventArgs e)
        {
            Console.WriteLine("This man is tycoon,and its net worth is " + e.RMoney);
        }

        private static void P_JudgeAdultEvent(object sender, PersonEventArgs e)
        {
            Console.WriteLine("The current person is adult and his age is " + e.EAge);
        }


    }

    

    public class Person
    {
        public event JudgeAdultHandler JudgeAdultEvent;
        public event JudgeRichHandler JudgeRichEvent;
        public int Age { get; set; }
        public string Name { get; set; }

        public decimal RMoney { get; set; }
        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }

        public Person(int age,decimal rMoney)
        {
            Age = age;
            RMoney = rMoney;
        }
        protected virtual void OnJudgeAdultEvent()
        {
            if(JudgeAdultEvent!=null)
            {
                JudgeAdultEvent(this, new PersonEventArgs(Age));
            }
        }

        protected virtual void OnJudgeRichPerson()
        {
            if (JudgeRichEvent != null)
            {
                JudgeRichEvent(this, new RichPersonEventArgs(RMoney));
            }
        }


        public override string ToString()
        {
            return string.Format("Age:{0},Name:{1},PMoney:{2}\n", Age, Name,RMoney);
        }

        public void JudgeAdult(Person p)
        {
            if(p.Age>18)
            {
                OnJudgeAdultEvent();
            }
        }

        public void JudgeRich(Person p)
        {
            if(p.RMoney>100000000m)
            {
                OnJudgeRichPerson();
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

    public class RichPersonEventArgs:EventArgs
    {
        public decimal RMoney { get; set; }
        public RichPersonEventArgs(decimal rMoney)
        {
            RMoney = rMoney; 
        }
    }
}
