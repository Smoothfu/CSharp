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
            //FlushRedisDbs(0);
        }

        static void RedisDemo()
        {
            using (var redis = ConnectionMultiplexer.Connect("localhost"))
            {
                IDatabase db = redis.GetDatabase(0);
                for(int i=0;i<100000;i++)
                { 
                    string redisKey = Guid.NewGuid().ToString();                    
                    db.StringSet(redisKey, redisKey);
                }   
            }
        }


        //dbIndex is between 0 and 15
        static void FlushRedisDbs(int dbIndex)
        {
            using(ConnectionMultiplexer redis= ConnectionMultiplexer.Connect("localhost,allowAdmin=true"))
            {
                var server = redis.GetServer("localhost:6379");
                server.FlushDatabase(dbIndex);
            }
        }
    }
}
