using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary10;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;
            try
            {
                Uri uri = new Uri("http://localhost:8735/Design_Time_Addresses/WcfServiceLibrary10/Service1/mex");
                host = new ServiceHost(typeof(MathService), new Uri(ConfigurationManager.AppSettings["baseUrl"]));
                host.Faulted += Host_Faulted;
                ServiceEndpoint serviceEndpoint = host.AddServiceEndpoint(typeof(IMathService), new NetTcpBinding(), ConfigurationManager.AppSettings["endpointUrl"]);

                //公布元数据
                host.Description.Behaviors.Add(new ServiceMetadataBehavior() { HttpGetEnabled = true });
                host.AddServiceEndpoint(typeof(IMathService), MetadataExchangeBindings.CreateMexHttpBinding(), "mex");
                host.Open();
                Console.WriteLine("The service has been started!\n");
                Console.WriteLine("{0},{1}", serviceEndpoint.Address.ToString(), serviceEndpoint.Binding.Name);

                Console.ReadLine();
            }
            finally
            {
                if(host.State==CommunicationState.Faulted)
                {
                    host.Abort();
                }
                else
                {
                    host.Close();
                }
            }

           

        }

        private static void Host_Faulted(object sender, EventArgs e)
        {
            Console.WriteLine("The MathService host has faulted.\n");
        }
    }
}
