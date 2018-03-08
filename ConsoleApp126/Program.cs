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
            Thread th = new Thread(() =>
              {
                  AddMethod(100, 1000000, 10000000);
              });
            Console.WriteLine("Now is:{0},ThreadState:{1}\n", DateTime.Now.ToString("yyyy-MM-dd:hh-mm-ss:fff"), th.ThreadState);
            th.Start();
            Console.WriteLine("Now is:{0},ThreadState:{1}\n", DateTime.Now.ToString("yyyy-MM-dd:hh-mm-ss:fff"), th.ThreadState);

            while(!(th.ThreadState==ThreadState.Stopped))
            {
                Console.WriteLine("Now is:{0},ThreadState:{1}\n", DateTime.Now.ToString("yyyy-MM-dd:hh-mm-ss:fff"), th.ThreadState);
            }

            if(th.ThreadState == ThreadState.Stopped)
            {
                Console.WriteLine("Now is:{0},ThreadState:{1}\n", DateTime.Now.ToString("yyyy-MM-dd:hh-mm-ss:fff"), th.ThreadState);

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
