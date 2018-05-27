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
        public static List<Person> PersonList { get; set; }
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.CreatePrivateQueues();
            Console.ReadLine();
        }

        //Creates private queues and sens a message.
        public void CreatePrivateQueues()
        {

            PersonList = new List<Person>
            {
                new Person(1, "Fred"),
                new Person(2, "Bill Gates"),
                new Person(3, "Michael Bloomberg")
            };

            string mqPath = ".\\Private$\\MyQueue2";
            MessageQueue.Delete(mqPath);
            if(!MessageQueue.Exists(mqPath))
            {
                MessageQueue.Create(mqPath);
            }

            //Open queue.
            MessageQueue queue = new MessageQueue(mqPath);
            queue.Purge();

            //Create message
            Message msg = new Message();

            msg.Body = PersonList;

            msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(List<Person>) });

            //put message into queue
            queue.Send(msg);

            var allMessages = queue.GetAllMessages();

            Message receiveMsg = new Message();
            receiveMsg = queue.Receive();
            receiveMsg.Formatter = new XmlMessageFormatter(new Type[] { typeof(List<Person>) });
            
            var bodyResult=receiveMsg.Body as List<Person>;
            if (bodyResult != null && bodyResult.Any())
            {
                bodyResult.ForEach(x =>
                {
                    Console.WriteLine(x.ToString());
                });
            }          
            
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
            ToString();
        }

        public override string ToString()
        {
            return string.Format("Id:{0},Name:{1}\n", Id, Name);
        }

    }
}
