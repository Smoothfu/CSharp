﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace ConsoleApp257
{
  
    class Program
    {
        static void Main(string[] args)
        {
            string host;
            int port = 80;
            if(args.Length==0)
            {
                //If no server name is passed as argument to this program,use the current host name as the default.
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


        private static Socket ConnectSocket(string server,int port)
        {
            Socket s = null;
            IPHostEntry hostEntry = null;

            //Get host related information.
            hostEntry = Dns.GetHostEntry(server);

            // Loop through the AddressList to obtain the supported AddressFamily. This is to avoid
            // an exception that occurs when the host IP Address is not compatible with the address family
            // (typical in the IPv6 case).
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
            string request = "GET/HTTP/1.1\r\nHost: " + server + "\r\nConnection:Close\r\n\r\n";
            byte[] byteSend = Encoding.UTF8.GetBytes(request);
            byte[] bytesReceived = new Byte[256];

            //Creates a socket connection with the specified server and port.
            Socket s = ConnectSocket(server, port);
            if(s==null)
            {
                return ("Connection failed!");
            }

            //Send request to the server.
            s.Send(byteSend, byteSend.Length, 0);

            //Receive the server home page content.
            int bytes = 0;
            string page = "Default HTML page on " + server + ":\r\n";

            //The following will block until the page is transmitted.
            do
            {
                bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                page = page + Encoding.UTF8.GetString(bytesReceived, 0, bytesReceived.Length);

            } while (bytes > 0);
            return page;
        }
    }





}
