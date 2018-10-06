using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary10;
using System.ServiceModel;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary10/Service1/mex");
            using (ServiceHost host = new ServiceHost(typeof(MathService), uri))
            {
                try
                {
                    if(host.State!=CommunicationState.Opened)
                    {
                        host.Open();
                    }                    
                    Console.WriteLine("The service has been started!");
                    Console.ReadLine();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ReadLine();

        }
    }
}
