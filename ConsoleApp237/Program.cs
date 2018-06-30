using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp237
{
    public delegate void AddHandler(int x, AddEventArgs e);
    class Program
    {         
        static void Main(string[] args)
        {
            AddClass add = new AddClass(253452454, 425456345);
            add.AddEvent += Add_AddEvent;
            add.JudgeXGreter();
            Console.ReadLine();
        }

        private static void Add_AddEvent(int x, AddEventArgs e)
        {
            Console.WriteLine("Now x is :{0},time is :{1}\n", e.AX, e.Dt);
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public Person(int age,string name)
        {
            Age = age;
            Name = name;
        }

        public void DescPerson(object obj)
        {
            var personObj = obj as Person;
            if(personObj!=null)
            {
                Console.WriteLine(personObj.ToString());
            }
        }
        public override string ToString()
        {
            return string.Format("Name:{0},Age:{1}",Name,Age);
        }
    }

    public class AddClass
    {
        public event AddHandler AddEvent;
        public int X { get; set; }
        public int Y { get; set; }

        public AddClass(int x,int y)
        {
            X = x;
            Y = y;
        }

        public void JudgeXGreter()
        {
            if(X>1000000)
            {
                OnRaiseAddEvent();
            }
        }

        protected virtual void OnRaiseAddEvent()
        {
             if(AddEvent!=null)
            {
                AddEvent(X, new AddEventArgs(X,DateTime.Now));
            }

        }
    }

    public class AddEventArgs : EventArgs
    {
        public int AX { get; set; }
        public DateTime Dt { get; set; }
        public AddEventArgs(int aX,DateTime dt)
        {
            AX = aX;
            Dt = dt;
        }
    }
}
