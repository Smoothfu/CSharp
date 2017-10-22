using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp84
{
    class Program
    {
        static Socket client;
        static void Main(string[] args)
        {
            //Create the object of IPEndPoint,which can receive any client ip address whose port is 9050
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9050);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                ProtocolType.Tcp);
            //Binding
            server.Bind(ip);
            //Listening
            server.Listen(20);
            Console.WriteLine("Listening...");

            //
            while (true)
            {
                client = server.Accept();

                //new and start a task
                Task.Factory.StartNew(() =>
                {
                    SendData();
                });
            }

            Console.ReadLine();
        }

        static private void SendData()
        {
            if(null!=client)
            {
                Console.WriteLine("Client: " + client.RemoteEndPoint + " connected to the server");
                string data = "Hello client";
                //convert the string to byte array
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                //send data to the client
                client.Send(msg);
                Console.WriteLine("Send data completed " + data);
                client.Close();
            }
        }
    }
}
