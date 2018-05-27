using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace ConsoleApp182
{
    class Program
    {
        static string queuePath=".\\Private$\\MQ";        
        
        static MessageQueue msgQueue = new MessageQueue(queuePath);
        static void Main(string[] args)
        {
            Program obj = new Program();

            if(!MessageQueue.Exists(queuePath))
            {
                MessageQueue.Create(queuePath);
            }

            obj.SendQueue();
            obj.ReceiveQueue();
            Console.ReadLine();
        }

        void SendQueue()
        {
            Person person = new Person
            {
                PId = 1,
                PName = "Fred"
            };

            msgQueue.Send(person, MessageQueueTransactionType.Automatic);
        }

        void ReceiveQueue()
        {
            Message msg = msgQueue.Receive();
            Person p = msg.Body as Person;
            if (p != null)
            {
                Console.WriteLine("PId:{0},PName:{1}\n", p.PId, p.PName);
            }
        }
    }

    public class Person
    {
        public int PId { get; set; }
        public string PName { get; set; }
    }
}
