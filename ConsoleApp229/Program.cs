﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ConsoleApp229
{
    public delegate void JudgeAdultHandler(object sender, PersonEventArgs e);
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("The ManagedThreadId in Main method is {0}\n", Thread.CurrentThread.ManagedThreadId);
            Person p = new Person(31, "Floomberg");
            p.JudgeAdultEvent += P_JudgeAdultEvent;
            p.JudgePerson(p);
            Console.ReadLine();
        }

        private static void P_JudgeAdultEvent(object sender, PersonEventArgs e)
        {
            Console.WriteLine("This is an adult and its age is "+e.PAge);
        }

        static void Add(int x,int y)
        {
            Console.WriteLine("The ManagerThreadId in Add method is {0}\n", Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
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
                JudgeAdultEvent(this, new PersonEventArgs(Age));
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
        public PersonEventArgs(int pAge)
        {
            PAge = pAge;
        }        
    }
}
