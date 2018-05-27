using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace ConsoleApp180
{
    class Program
    {
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.CreatePrivateQueues();
            Console.ReadLine();
        }

        //Creates private queues and sens a message.
        public void CreatePrivateQueues()
        {
            string mqPath = ".\\Private$\\MyQueue";
            if(!MessageQueue.Exists(mqPath))
            {
                MessageQueue.Create(mqPath);
            }
            MessageQueue mq = new MessageQueue(mqPath);
            mq.Send("Private queue by path name!");

            Message msg = mq.Receive();
            string msgString = msg.Body.ToString();
            Console.WriteLine(msgString);         
        }        
    }
}
