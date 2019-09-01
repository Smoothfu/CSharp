using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ConsoleApp370
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisDemo();
        }

        static void RedisDemo()
        {
            using (var conn = ConnectionMultiplexer.Connect("localhost"))
            {
                IDatabase db = conn.GetDatabase(2);
                for(int i=0;i<100000;i++)
                { 
                    string redisKey = Guid.NewGuid().ToString();                    
                    db.StringSet(redisKey, redisKey);
                }   
            }
        }
    }
}
