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
            Person p = new Person(1,"Fred");

            msg.Body = p;

            //msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(Person) });

            //put message into queue
            queue.Send(msg);

            Message receiveMsg = new Message();
            receiveMsg = queue.Receive();
            receiveMsg.Formatter = new XmlMessageFormatter(new Type[] { typeof(Person) });
            string queueMsg = receiveMsg.Body.ToString();
            Console.WriteLine(queueMsg);
        }        
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person(int id,string name)
        {
            Id = id;
            Name = name;
        }
        public Person()
        {

        }

        public override string ToString()
        {
            return string.Format("Name:{0}\nId:{1}\n", Name, Id);
        }

    }
}
