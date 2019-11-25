using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace ConsoleApp396
{
    class Program
    {
        private static Socket ConnectSocket(string server,int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            //Get host related information
            hostEntry = Dns.GetHostEntry(server);

            foreach(IPAddress address in hostEntry.AddressList)
            {
                IPEndPoint ipe = new IPEndPoint(address, port);
                Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                tempSocket.Connect(ipe);

                if (tempSocket.Connected)
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
        private static string SocketSendReceive(string server,int port)
        {
            string request = "GET / HTTP/1.1\r\nHost: " + server + "\r\nConnection:Close\r\n\r\n";
            byte[] bytesSent = Encoding.ASCII.GetBytes(request);
            byte[] bytesReceived = new byte[256];
            string page = "";

            using(Socket s = ConnectSocket(server, port))
            {
                if(s==null)
                {
                    return ("Connection failed!");
                }

                s.Send(bytesSent, bytesSent.Length, 0);
                int bytes = 0;
                page = "Default HTML page on " + server + ":\r\n";
                do
                {
                    bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                    page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes);
                } while (bytes > 0);
            }
            return page;
        }
        public static void Main(string[] args)
        {
            string host;
            int port = 80;
            if(args.Length==0)
            {
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
    }
}
