using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp204
{
    class Program
    {
        static void Main(string[] args)
        {
            // http://localhost:8117/Service1.svc
            //http://localhost:7288/Service1.svc
            string connString = @"Server=FRED\SQLEXPRESS;Database=AdventureWorks2014;Integrated Security=SSPI;";
            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();
            string connectionStatus = client.SqlConnectionStatus(connString);
            Console.WriteLine(connectionStatus);

            Console.ReadLine();
        }
    }
}
