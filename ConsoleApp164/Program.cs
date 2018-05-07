using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp164
{
    public delegate int AddDel(int x, int y, int z);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The main thread managerid is :{0}\n", Thread.CurrentThread.ManagedThreadId);
            AddDel addDel = new AddDel(Add);
            AsyncCallback asyncCallback = new AsyncCallback(AddComplete);

            IAsyncResult asyncResult = addDel.BeginInvoke(10, 10,10, new AsyncCallback(AddComplete), "This is the delegate BeginInvoke!\n");
            int answer = addDel.EndInvoke(asyncResult);
            string msgResult = asyncResult.AsyncState.ToString();
            Console.WriteLine("The final result is :{0}\n", answer);
            Console.WriteLine("The AsyncState is :{0}\n", msgResult);
            Console.ReadLine();
        }

        static int Add(int x,int y,int z)
        {
            Console.WriteLine("The Add method  thread Id is {0}\n", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);
            return x + y + z;
        }

        static void AddComplete(IAsyncResult asyncResult)
        {
            Console.WriteLine("The Add method has been completed!\n");
        }
    }
}
