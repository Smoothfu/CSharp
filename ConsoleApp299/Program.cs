using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp299
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> intStack = new Stack<int>();
            Random rnd = new Random();
            Console.WriteLine("The push in order:\n");
            for(int i=0;i<10;i++)
            {
                int tempValue = rnd.Next(0, int.MaxValue);
                intStack.Push(tempValue);
                Console.Write(tempValue + "\t");
            }

            Console.WriteLine("\nThe pop up order:\n");
            while(intStack.Count>0)
            {
                Console.Write(intStack.Pop() + "\t");
            }
            Console.ReadLine();
        }

        static void ReadNumber()
        {
            int num;
            string sNum;
            Console.Write("Enter a number: ");
            sNum = Console.ReadLine();
            num = Int32.Parse(sNum);
            Console.WriteLine();
            Console.WriteLine(num);
        }
        static void GetSingleton()
        {
            Singleton instance = Singleton.GetSingletonInstance();
            Console.WriteLine(instance.GetType().Name);
        }
        static void OutputTime()
        {
            Console.WriteLine(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }
    }

    public  sealed  class Singleton
    {
        private static Singleton Instance;
        private Singleton()
        { 
        }

        private static object objLock = new object();

        public static Singleton GetSingletonInstance()
        {
            lock(objLock)
            {
                if(Instance==null)
                {
                    Instance = new Singleton();
                }
            }
            return Instance;
        }
    }
}
