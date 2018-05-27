using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Windows.Forms;

namespace ConsoleApp179
{
    class Program
    {
        //Provides an entry point into the application.
        static void Main(string[] args)
        {
            //Create a new instance of the class.
            Program obj = new Program();
            obj.SendMessageQueue();
            Console.ReadLine();
        }

        public void CreateMessageQueue()
        {
            //设置消息队列
            string path = ".\\private$\\test";

            //判断路径是否存在
            if(!MessageQueue.Exists(path))
            {
                //如果不存在就创建
                MessageQueue.Create(path);
            }
            System.Windows.Forms.MessageBox.Show("OK");
        }

        public void SendMessageQueue()
        {
            //设置消息队列路径
            string path = ".\\private$\\mq";

            //创建指定路径下的消息队列对象
            //判断路径是否存在
            if (!MessageQueue.Exists(path))
            {
                //如果不存在就创建
                MessageQueue.Create(path);
            }

            MessageQueue messageQueue = new MessageQueue(path);
            messageQueue.Send("Send By Message Queue!");

            //获取单挑数据，如果没有数据，当前进程会被阻塞
            System.Messaging.Message msg = messageQueue.Receive();

            //获取Message内的内容
            string messgae = msg.Body.ToString();

            MessageBox.Show(messgae);                     
        }

        //Reference public queues.
        public void SendPublic()
        {
            MessageQueue messageQueue = new MessageQueue(".\\myQueue");
            messageQueue.Send("Public queue path name.");
            return;
        }

        //References private queues
        public void SendPrivate()
        {
            MessageQueue messageQueue = new MessageQueue(".\\Private$\\MyQueue");
            messageQueue.Send("Private queue by path name.");
            return;
        }

        //References queues by label.
        public void SendByLabel()
        {
            MessageQueue messageQueue = new MessageQueue("Label:TheLabel");
            messageQueue.Send("Queue by label.");
            return;
        }

        //References queues by format name.
        public void SendByFormatName()
        {
            MessageQueue messageQueue = new MessageQueue("FormatName:Public=5A5F7535-AE9A-41d4-935C-845C2AFF7112");
            messageQueue.Send("Queue by format name.");
            return;
        }

        //References computer journal queues.
        public void MonitorComputerJournal()
        {
            MessageQueue computerJournal = new MessageQueue(".\\Journal$");
            while(true)
            {
                System.Messaging.Message journalMessage = computerJournal.Receive();
            }
        }

        //References queue journal queues.
        public void MonitorQueueJournal()
        {
            MessageQueue queueJournal = new MessageQueue(".\\myQueue\\Journal$");
            while(true)
            {
                System.Messaging.Message journalMessage = queueJournal.Receive();
            }
        }

        //References dead-letter queues
        public void MonitorDeadLetter()
        {
            MessageQueue deadLetter = new MessageQueue(".\\DeadLetter$");
            while(true)
            {
                System.Messaging.Message deadMessage = deadLetter.Receive();
            }
        }

        //References transactional dead-letter queues.
        public void MonitorTransactionalDeadLetter()
        {
            MessageQueue TxDeadLetter = new MessageQueue(".\\XactDeadLetter$");
            while(true)
            {
                System.Messaging.Message txDeadLetter = TxDeadLetter.Receive();
                //Process the transactional dead-letter message.
            }
        }


    }
}
