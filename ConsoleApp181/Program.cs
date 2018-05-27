using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace ConsoleApp181
{
    class Program
    {
        static string queuePath=@".\private$\myQueue";
        static void Main(string[] args)
        {
            CreateQueue(queuePath);
            Console.ReadLine();
        }

        public static void  CreateQueue(string queuePath)
        {
            try
            {
                if(!MessageQueue.Exists(queuePath))
                {
                    MessageQueue.Create(queuePath);
                }
                else
                {
                    Console.WriteLine("The {0} has exists!", queuePath);
                }
            }
            catch(MessageQueueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Connect to the MessageQueue and send message to queue.
        public static void SendMessage()
        {
            try
            {
                //Connect to the local queue.
                MessageQueue myQueue = new MessageQueue(queuePath);
                Message msg = new Message();
                msg.Body = "MessageQueue myQueue = new MessageQueue(queuePath);";

                msg.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

                //send the message to the queue.
                myQueue.Send(msg);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Connect the MessageQueue and receive from message
        public static void ReceiveMessage()
        {
            //Connect to the local queue.
            MessageQueue myQueue = new MessageQueue(queuePath);
            myQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            try
            {
                //Receive message from queue.
                Message myMsg = myQueue.Receive();

                //get the content of the message.
                string context = (string)myMsg.Body;
                Console.WriteLine("The content is " + context);
            }
            catch (MessageQueueException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch(InvalidCastException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Clear the specified queue
        public static void ClearMessage()
        {
            MessageQueue myQueue = new MessageQueue(queuePath);
            myQueue.Purge();
        }

        //Connect to the queue and retrieve from the queue
        public static void GetAllMessages()
        {
            //Connect to the local queue
            MessageQueue myQueue = new MessageQueue(queuePath);
            Message[] allMessages = myQueue.GetAllMessages();
            XmlMessageFormatter formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            for(int i=0;i<allMessages.Length;i++)
            {
                allMessages[i].Formatter = formatter;
                Console.WriteLine(allMessages[i].Body.ToString());
            }
        }
    }
}
