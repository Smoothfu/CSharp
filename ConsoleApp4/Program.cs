using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Security;

namespace ConsoleApp4
{
    class Program
    {
        public void ThreadMethod()
        {
            for(int i=0;i<10;i++)
            {
                Thread thread = Thread.CurrentThread;
                Console.WriteLine(thread.Name + " =" + i);
                try
                {
                    Thread.Sleep(1000);
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                catch(ThreadInterruptedException ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                catch(SecurityException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                
            }
        }
         
        static void Main(string[] args)
        {
            Console.WriteLine("Before start thread");
            Program obj1 = new Program();
            Program obj2 = new Program();

            Thread thread1 = new Thread(obj1.ThreadMethod);
            Thread thread2 = new Thread(obj2.ThreadMethod);

            thread1.Name = "Thread 1";
            thread2.Name = "Thread 2";
            thread1.Start();
            thread2.Start();

            thread1.Abort();
            thread2.Abort();

            Console.WriteLine("After Abort");

            Console.WriteLine("Thread1 state: " + thread1.ThreadState);
            Console.WriteLine("Thread2 state: " + thread2.ThreadState);


            try
            {
                thread1.Start();
                thread2.Start();
            }

            catch(ThreadStateException te)
            {
                Console.WriteLine(te.ToString());
            }

            
            Console.WriteLine("Main thread ended");

            Console.ReadLine();
        }   
    }
}
