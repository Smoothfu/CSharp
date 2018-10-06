using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary11;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IMathService> factory = new ChannelFactory<IMathService>(new NetTcpBinding(), "net.tcp://localhost:8733/Design_Time_Addresses/WcfServiceLibrary11/Service1/mex");
            var channel = factory.CreateChannel();
            int result = channel.AddMethod(1000000, 23000000);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
