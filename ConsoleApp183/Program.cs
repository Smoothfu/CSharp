using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace ConsoleApp183
{
    class Program
    {
        static string queuePath = ".\\Private$\\myQueue";
        static void Main(string[] args)
        {
            if(!MessageQueue.Exists(queuePath))
            {
                MessageQueue.Create(queuePath);
            }
            SendPublic();
            Console.ReadLine();
        }

        //References public queues.
        static void SendPublic()
        {
            MessageQueue myQueue = new MessageQueue(queuePath);
            for(int i=0;i<100;i++)
            {
                myQueue.Send("Public queue by path name. Now is " + DateTime.Now.ToString("yyyyMMdd-HHmmssfff"));
            }
            
            myQueue.Formatter = new XmlMessageFormatter(new Type[] {typeof(string)});

            Message[] allMessages = myQueue.GetAllMessages();

            if(allMessages!=null && allMessages.Any())
            {
                foreach(Message msg in allMessages)
                {
                    Console.WriteLine(msg.Body.ToString());
                }
            }
            
            return;
        }
    }
}
