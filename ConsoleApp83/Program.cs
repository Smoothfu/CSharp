using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp83
{
    class Program
    {
        static Socket client;
        static void Main(string[] args)
        {
            //创建IPEndPoint对象，表示接受任何端口9050的客户机地址
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 9060);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定
            server.Bind(ipep);
            //监听
            server.Listen(20);
            Console.WriteLine("Listening...");

            //下面这段代码阻塞，可以用新线程执行，但可能会出问题

            //收到客户端请求
            client = server.Accept();

            //开新线程发送数据
            Thread recvThread = new Thread(SendData);
            //后台线程
            recvThread.IsBackground = true;
            //启动消息服务线程
            recvThread.Start();

        }

        static private void SendData()
        {
            if (client != null)
            {
                Console.WriteLine("Client " + client.RemoteEndPoint + " connected to the server");
                string data = "hello client";
                //将string 转化为byte数组
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                //向客户端发送数据
                client.Send(msg);
                Console.WriteLine("Send data: " + data);
                client.Close();
            }
        }
    }
}
