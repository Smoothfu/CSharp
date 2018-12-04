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
            Singleton instance = Singleton.GetSingletonInstance();
            Console.WriteLine(instance.GetType().Name);
            Console.ReadLine();
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
