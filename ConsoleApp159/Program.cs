using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.IO;

namespace ConsoleApp159
{
    class Program
    {
     static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with DirectoryInfo*****\n");
            ShowWindowDirectoryInfo();
            Console.ReadLine();
        }

        static void ShowWindowDirectoryInfo()
        {
            //Dump directory information.
            DirectoryInfo dir = new DirectoryInfo(@"D:\C\ConsoleApp159\ConsoleApp159New");
            dir.Create();
            Console.WriteLine("*****Directory Info*****\n");
            Console.WriteLine("FullName:{0}\n", dir.FullName);
            Console.WriteLine("Name:{0}\n", dir.Name);
            Console.WriteLine("Parent:{0}\n", dir.Parent);
            Console.WriteLine("Creation:{0}\n", dir.CreationTime);
            Console.WriteLine("Attributes:{0}\n", dir.Attributes);
            Console.WriteLine("Root:{0}\n", dir.Root);
            Console.WriteLine("*************************************************************\n");

        }
        static async Task<int> AccessTheWebAsync()
        {
            //You need to add a reference to System.Net.Http to declare client.
            HttpClient client = new HttpClient();

            //GetStringAsync returns a Task<string> that means that when you await the task you'll get a string 
            Task<string> getStringTask = client.GetStringAsync("http://msdn.microsoft.com");

            //You can do work here that does not rely on the string from GetStringAsync .
             

            string urlContents = await getStringTask;
            return urlContents.Length;
        }

        static async Task Sum(object data)
        {
            await Task.Run(() =>
            {
                var addParam = data as AddParams;
                if(addParam!=null)
                {
                    Console.WriteLine("Sum method ID of thread in Add():{0}\n", Thread.CurrentThread.ManagedThreadId);
                    Console.WriteLine("{0}+{1}={2}\n", addParam.A, addParam.B, addParam.A + addParam.B);
                }
            });
        }

        private static async Task AddAsync()
        {
            Console.WriteLine("*****Adding with Thread objects*****\n");
            Console.WriteLine("AddAsync method ID of thread in Main():{0}\n", Thread.CurrentThread.ManagedThreadId);

            AddParams ap = new AddParams(1000000, 100000000);
            await Sum(ap);
            Console.WriteLine("Other thread is done!\n");
        }
    }

    public class AddParams
    {
        public int A { get; set; }
        public int B { get; set; }

        public AddParams(int a,int b)
        {
            A = a;
            B = b;
        }
    }
}
