using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace ConsoleApp370
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            log.Info("Start");
            //RedisDemo();
            RedisAsyncDemo();
            //FlushRedisDbs(0);
            stopwatch.Stop();
            //log.Info($"Cost synchronous {stopwatch.ElapsedMilliseconds} milliseconds!");
            log.Info($"Cost asynchronous{stopwatch.ElapsedMilliseconds} milliseconds!");
        }


        static async Task RedisAsyncDemo()
        {
            await RedisDemoAsync();
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

        static async Task RedisDemoAsync()
        {
            using (var redis = ConnectionMultiplexer.Connect("localhost"))
            {
                IDatabase db = redis.GetDatabase(0);
                for (int i = 0; i < 100000; i++)
                {
                    string redisKey = Guid.NewGuid().ToString();
                    await db.StringSetAsync(redisKey, redisKey);
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
