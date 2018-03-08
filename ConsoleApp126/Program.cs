using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp126
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person(1, "Fred");
            Thread pThread = new Thread(new ThreadStart(p.DescribePerson));
            Console.WriteLine(pThread.ThreadState + "\n");
            pThread.Start();
            Console.WriteLine(pThread.ThreadState+"\n");

            while(!(pThread.ThreadState==ThreadState.Stopped))
            {
                Console.WriteLine("Now is :{0}\n", DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
            }

            if(pThread.ThreadState==ThreadState.Stopped)
            {
                Console.WriteLine("Now The thread finished,it's {0}\n", DateTime.Now.ToString("yyyy-MM-dd:HH-mm-ss:fff"));
            }
            Console.ReadLine();
        }

        static void AddMethod(int x,int y,int z)
        {
            Thread addThread = Thread.CurrentThread;
            Console.WriteLine("Thread Id:{0}\n", addThread.ManagedThreadId);

            Console.WriteLine("{0}+{1}+{2}={3}\n", x, y, z, x + y + z);
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int pId,string pName)
        {
            Id = pId;
            Name = pName;
        }

        public void DescribePerson()
        {
            Console.WriteLine("Name:{0},Id:{1}\n", Name, Id);
        }

        public override string ToString()
        {
            return string.Format("The person's name is :{0},and Id is:{1}\n", Name, Id);
        }
    }
}
