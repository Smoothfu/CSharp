using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp98
{
    class Program
    {
        static void Main(string[] args)
        {

            //show the foreground and background thread
            BackGroundTest backobj = new BackGroundTest(10);

            //create the foreground thread
            Thread foreThread = new Thread(new ThreadStart(backobj.RunLoop));
            //name the thread
            foreThread.Name = "Foreground thread";

            BackGroundTest backObj2 = new BackGroundTest(20);
            //create the background thread
            Thread backThread = new Thread(new ThreadStart(backObj2.RunLoop));
            //set the thread as background thread
            backThread.IsBackground = true;

            //start the thread
            foreThread.Start();
            backThread.Start();
            Console.ReadLine();
        }
    }

    class BackGroundTest
    {
        private int Count;
        public BackGroundTest(int count)
        {
            this.Count = count;
        }

        public void RunLoop()
        {
            //get the name of the current thread
            string threadName = Thread.CurrentThread.Name;
            for(int i=0;i<Count;i++)
            {
                Console.WriteLine("{0} count:{1}", threadName, i.ToString());
            }

            Console.WriteLine("{0} counting completed ", threadName);
        }
    }
}
