using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Windows.Markup;


namespace ConsoleApp248
{
    interface IPointy
    {
       void AddMethod(int x, int y, int z);
       string IName { get; set; }

        void SubtractMethod(int x, int y, int z);
    }

    interface IPointy2
    {
        int Points { get; }
    }
    class Program:IPointy, IPointy2
    {
        private string _mIName;
        public string IName {
        get { return _mIName; }
            set { _mIName = value; }
           }

        public int Points
        {
            get
            {
                return 3;
            }
        }

        public Program(string name)
        {
            _mIName = name; 
        }

        static void Main(string[] args)
        {
            Console.WriteLine("The main ManagedThreadId is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Program obj = new Program("Program Class");
            Thread thread = new Thread(() =>
              {
                  AddMethod(1334, 4764567);
                  obj.AddMethod(452346245, 3445346, 456345645);
                  Console.WriteLine(obj.IName);
                  obj.SubtractMethod(256245634, 0, 0);
                  Console.WriteLine(obj.Points);
              });
            thread.Start();
            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("The AddMethod ManagedThreadId is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
        }

        public void AddMethod(int x, int y, int z)
        {
            Console.WriteLine("The overload AddMethod {0}+{1}+{2}={3}\n", x, y, z, x + y + z);
        }

        public void SubtractMethod(int x, int y, int z)
        {
            Console.WriteLine("The SubtractMethod ThreadId:{0}\n", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("{0}-{1}-{2}={3}\n", x, y, z, x - y - z);
        }
    }
}
