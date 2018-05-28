using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp186;
using System.ServiceModel;

namespace ConsoleApp186
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(ConsoleApp186.Service1)))
            {
                host.Open();
                Console.WriteLine("The server has started!\n");
                
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
