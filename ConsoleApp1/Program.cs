using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary4;
 

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = Task.Run(() =>
            {
                AddService.Service1Client client = new AddService.Service1Client();
                int result = client.AddMethod(100, 1000000);
                Console.WriteLine(result);
            });
           
            Console.ReadLine();
        }
    }
}
