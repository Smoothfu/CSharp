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
            int x = 789034534, y = 3452345;
            WcfServiceLibrary10.MathService mathService = new MathService();
            int result = mathService.AddMethod(x, y);
            Console.WriteLine("{0}+{1}={2}\n", x, y, result);


            //Uri uri = new Uri("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary10/Service1/mex");
            //using (ServiceHost host = new ServiceHost(typeof(MathService), uri))
            //{
            //    try
            //    {
            //        if(host.State!=CommunicationState.Opened)
            //        {
            //            host.Open();
            //        }                    
            //        Console.WriteLine("The service has been started!");
            //        Console.ReadLine();
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //    }
            //}
            Console.ReadLine();

        }
    }
}
