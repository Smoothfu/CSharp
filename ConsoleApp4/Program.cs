using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp4
{
    class Program
    {
         
        static void Main(string[] args)
        {
            Console.WriteLine("Before start thread.");

            Thread thread1 = new Thread(ThreadMethod1);
            Thread thread2 = new Thread(ThreadMethod2);
            thread1.Start();
            thread1.Join();
            thread2.Start();
            thread2.Join();

            for(int i=0;i<10;i++)
            {
                Console.WriteLine("The main thread :{0}", i);
            }
            
            Console.ReadLine();
        }  
        
        public static void ThreadMethod1()
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine("Thread1 {0}",i);
            }
        }

        public static void ThreadMethod2()
        {
            for(int i=0;i<10;i++)
            {
                Console.WriteLine("Thread2 {0}", i);
            }
        }

    }
}
