using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace ConsoleApp210
{
    class Program
    {
        static void Main(string[] args)
        {
            string host;
            int port = 80;

            if(args.Length==0)
            {
                //If no server name is passed as argument to this program,use the current host name as the default
                host = Dns.GetHostName();
            }
            else
            {
                host = args[0];
            }

            string result = SocketSendReceive(host, port);
            Console.WriteLine(result);
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

        private static Socket ConnectSocket(string server,int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            //Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            //Loop through the AddressList to obtain the supported AddressFamily.This is to avoid 
            //an exception that occurs when the host IP Address is not compatible with the address family
            //typical in the IPv6 case.
            foreach(IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                tempSocket.Connect(ipe);

                if(tempSocket.Connected)
                {
                    s = tempSocket;
                    break;
                }
                else
                {
                    continue;
                }
            }
            return s;
        }

        //This method requests the home page content for the specified server.
        private static string SocketSendReceive(string server,int port)
        {
            string request = "GET/HTTP/1.1\r\nHost: " + server + "\r\nConnection:Close\r\n\r";
            Byte[] bytesSend = Encoding.ASCII.GetBytes(request);
            Byte[] bytesReceived = new Byte[256];

            //Create a socket connection with the specified server and port.
            Socket st = ConnectSocket(server, port);

            if(st==null)
            {
                return ("Connection failed");
            }

            //Send request to the server.
            st.Send(bytesSend, bytesSend.Length, 0);

            //Receive the server home page content.
            int bytes = 0;
            string page = "Default HTML page on " + server + ":\r\n";

            //The following will block until the page is  transmitted.
            do
            {
                bytes = st.Receive(bytesReceived, bytesReceived.Length, 0);
                page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
            }
            while (bytes > 0);
            return page;
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
