using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using StackExchange.Redis;

namespace ConsoleApp171
{
    class Program
    {
        static void Main(string[] args)
        {
            var obj = new Program();
            Console.WriteLine("Saving random data in cache!");
            obj.SaveBigData();

            Console.WriteLine("Reading data from cache!");
            obj.ReadData();
            Console.ReadLine();            
        }

        public void ReadData()
        {
            var cache = RedisHelper.Connection.GetDatabase();
            var deviceCount = 10;
            for(int i=0;i<deviceCount;i++)
            {
                var value = cache.StringGet($"Device_Status:{i}");
                Console.WriteLine($"Value={value}");
            }
        }

        public void SaveBigData()
        {
            var devicesCount = 10;
            var rnd = new Random();
            var cache = RedisHelper.Connection.GetDatabase();
            for(int i=0;i<devicesCount;i++)
            {
                int value = rnd.Next(0, 10000);                
                cache.StringSet($"Device_Status:{i}", value);
            }
        }
    }

    ///<summary>
    ///Redis操作类
    /// </summary>
    /// 
    public class RedisHelper
    {
        static RedisHelper()
        {
            RedisHelper.lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
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
