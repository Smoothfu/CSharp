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

            //Open queue.
            MessageQueue queue = new MessageQueue(mqPath);

            //Create message
            Message msg = new Message();
            msg.Body = "This is a fair world and everything depends on myself";

            msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            //put message into queue
            queue.Send(msg);
        }        
    }
}
