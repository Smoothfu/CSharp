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
        static List<Person> PersonList = new List<Person>();
        static MessageQueue msgQueue = new MessageQueue(queuePath);
        static MessageQueue messageQueue;
        static void Main(string[] args)
        {
            Program obj = new Program();

            if(!MessageQueue.Exists(queuePath))
            {
                MessageQueue.Create(queuePath);
            }

            messageQueue = new MessageQueue(queuePath);
            obj.SendQueue();
            obj.ReceiveQueue();
            Console.ReadLine();
        }

        void SendQueue()
        {
            PersonList.Add(new Person(1, "Fred"));
            PersonList.Add(new Person(2, "Floomberg"));
            PersonList.Add(new Person(3, "MichaelBloomberg"));
            PersonList.Add(new Person(4, "BillGates"));
            PersonList.Add(new Person(5, "ElonMusk"));
            PersonList.Add(new Person(6, "JeffBezos"));
            PersonList.Add(new Person(7, "LarryEllison"));
            PersonList.Add(new Person(8, "LarryPage"));
            PersonList.Add(new Person(9, "SergeyBrin"));
            PersonList.Add(new Person(10, "MarkZuckerberg"));

            messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(List<Person>) });
            messageQueue.Send(PersonList);
        }

        void ReceiveQueue()
        {
            Message msg = messageQueue.Receive();
            var personList = msg.Body as List<Person>;
            if(personList!=null && personList.Any())
            {
                personList.ForEach(x =>
                {
                    Console.WriteLine(x.ToString());
                });
            }             
        }
    }

    public class Person
    {
        public int PId { get; set; }
        public string PName { get; set; }

        public Person(int pId,string pName)
        {
            PId = pId;
            PName = pName;
        }


        public Person()
        {

        }
        public override string ToString()
        {
            return string.Format("PId:{0},Name:{1}\n", PId, PName);
        }
    }
}
