using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp85
{
    class Program
    {
        static Socket client;
        static Socket server;
        static void Main(string[] args)
        {
            //new IPEndPoint object,can receive any client with 9050 port
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 9050);
            //TCP
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //Binding
            server.Bind(ip);
            //Listening
            server.Listen(20);
            Console.WriteLine("Listening...");
            Accept();
            Console.ReadLine();
        }

        static async void Accept()
        {
            await AcceptAsync();
        }

        //Receive the request asynchronously
        static async Task AcceptAsync()
        {
            while(true)
            {
                //The server has accepted the client's request
                client = server.Accept();
                await SendData();
            }
        }

        // Send data asynchronously
        static async Task SendData()
        {
            if(client!=null)
            {
                Console.WriteLine("Client " + client.RemoteEndPoint + " has connected with the server");
                string data = "Hello World";
                //Convert the string to byte array
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                //send data to the client
                client.Send(msg);
                //add a asynchorous method
                await Task.Delay(1000);
                Console.WriteLine("Send data: " + data);
                client.Close();
            }
        }
    }
}
