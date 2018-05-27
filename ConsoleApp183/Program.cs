using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Threading;

namespace ConsoleApp183
{
    class Program
    {
        static string queuePath = ".\\Private$\\mq";

        //Define static class members.
        static ManualResetEvent signal = new ManualResetEvent(false);
        static int count = 0;
        static void Main(string[] args)
        {
            if(!MessageQueue.Exists(queuePath))
            {
                MessageQueue.Create(queuePath);
            }

            MessageQueue msgQueue = new MessageQueue(queuePath);
            msgQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });

            //Add an event handler for the ReceiveCompleted event.
            msgQueue.ReceiveCompleted += MsgQueue_ReceiveCompleted;

            //Begin the asynchronous receive operation.
            msgQueue.BeginReceive();

            signal.WaitOne();

            //Do other work on the current thread.

 
            Console.ReadLine();
        }

        private static void MsgQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                //Connect to the queue.
                MessageQueue mq = (MessageQueue)sender;

                //End the asynchronous receive operation.
                Message msg = mq.EndReceive(e.AsyncResult);
                Console.WriteLine(msg.Body.ToString());

                count += 1;
                if(count==10)
                {
                    signal.Set();
                }

                //Restart the asynchronous receive operation.
                mq.BeginReceive();
            }
            catch(MessageQueueException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
