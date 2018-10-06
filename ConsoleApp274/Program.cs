using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary9;
using System.ServiceModel;

namespace ConsoleApp274
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 56789, y = 6578900;
            Uri baseAddress = new Uri("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary9/Service1/mex");
            using (ServiceHost host = new ServiceHost(typeof(WcfServiceLibrary9.MathService), baseAddress))
            {
                host.Open();
                
                Console.WriteLine("The WCF service has started!\n");

                WcfServiceLibrary9.MathService service = new MathService();
                int result = service.Add(x, y);
                Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            }
            Console.ReadLine();
        }
    }
}
