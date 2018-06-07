using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;


namespace ConsoleApp210
{
    class Program
    {
        static void Main(string[] args)
        {
            SendMessage();
            ReceiveMessage();
            Console.ReadLine();
        }

        static void SendMessage()
        {
            //Create a new order
            Order newOrder = new Order(1, "od");

            //Connect to a queue on the local computer.
            MessageQueue myQueue = new MessageQueue(".\\Private$\\myQueue");

            //Send the ordr to the queue
            myQueue.Send(newOrder);
            return;
        }

        //Receive a message from queue.
        static void ReceiveMessage()
        {
            //Connect to the queue on the local computer.
            MessageQueue mq = new MessageQueue(".\\Private$\\myQueue");

            //set the formatter to indicate body contains an order.
            mq.Formatter = new XmlMessageFormatter(new Type[]
            {
                typeof(Order)
            });

            try
            {
                //Receive and format the message.
                System.Messaging.Message msg = mq.Receive();
                Order od = msg.Body as Order;
                if (od != null)
                {
                    Console.WriteLine("OrderId:{0},OrderName:{1}\n", od.OrderId, od.OrderName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

    }

    //This class represents an object the following example sends to a queue
    //and receives from a queue
    public class Order
    {
        public int OrderId { get; set; }
        public string OrderName { get; set; }

        public Order()
        {

        }
        public Order(int orderId,string orderName)
        {
            OrderId = orderId;
            OrderName = orderName;
        }
    }
}
