using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceStack.Commands;
using ServiceStack.Redis;
using ServiceStack.Text;
using ServiceStack.Common; 
using ServiceStack;
using StackExchange.Redis;

namespace ConsoleApp184
{
    class Program
    {
        static int devicesCount = 100000;
        static void Main(string[] args)
        {
            var obj = new Program();
            Console.WriteLine("Saving random data in cache!\n");
            obj.SaveBigData();

            Console.WriteLine("Reading data from cache!\n");
            obj.ReadData();

            Console.ReadLine();
        }

        public void ReadData()
        {
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            
            for(int i=0;i<devicesCount;i++)
            {
                var value = cache.StringGet($"Device_Status:{i}");
                Console.WriteLine($"Value={value}");
            }
        }

        public void SaveBigData()
        {
            
            var rnd = new Random();
            var cache = RedisConnectorHelper.Connection.GetDatabase();
            for(int i=0;i<devicesCount;i++)
            {
                var value = rnd.Next(0, 10000000);
                cache.StringSet($"Device_Status:{i}", value);
            }
        }
    }

    public class RedisConnectorHelper
    {
        static RedisConnectorHelper()
        {
            RedisConnectorHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
              {
                  return ConnectionMultiplexer.Connect("localhost");
              });
        }

        private static Lazy<ConnectionMultiplexer> lazyConnection;
        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
