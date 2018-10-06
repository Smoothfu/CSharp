using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary7;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:8733/Design_Time_Addresses/WcfServiceLibrary7/Service1/mex");
            
            //Create service host.
            ServiceHost host=new ServiceHost(typeof(WcfServiceLibrary7.MathService),httpUrl);
            
            //Add a service endpoint.
            host.AddServiceEndpoint(typeof(WcfServiceLibrary7.IMath),new WSHttpBinding(),"");

            //Enable metadata exchange.
            ServiceMetadataBehavior serviceMetadataBehavior = new ServiceMetadataBehavior();
            serviceMetadataBehavior.HttpGetEnabled = true;
            host.Description.Behaviors.Add(serviceMetadataBehavior);

            //start the service.
            host.Open();
            Console.WriteLine("Service is host at: " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press key to stop!");
            host.Close();
            Console.ReadLine();
        }
    }
}
