using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp313
{
    delegate void MathDel(int x, int y);
    delegate void CustomeEventHandler(object sender, CustomEventArgs e);
    

    class Program
    {
        public delegate void CallHandler(string msg);
        public event CallHandler CallEvent;
        static void Main(string[] args)
        {
            Friend fred = new Friend("Fred");
            Program p = new Program();
            p.CallEvent += new CallHandler(fred.SendMsg);
            p.OnCall("Any one received message!");

            Console.WriteLine("\n\n\n\n\n");
            p.CallEvent -= new CallHandler(fred.SendMsg);
            p.OnCall("Cancel message");
            
            
            Console.ReadLine();
        }

        public void OnCall(string msg)
        {
            if (CallEvent != null)
            {
                CallEvent(msg);
            }
        }
        static void Add(int x,int y)
        {
            Console.WriteLine($"{x}+{y}={x + y}!");
        }

        static void Subtract(int x,int y)
        {
            Console.WriteLine($"{x}-{y}={x - y}");
        }

        static void Multiply(int x,int y)
        {
            Console.WriteLine($"{x}*{y}={x * y}");
        }
    }

    public class CustomEventArgs:EventArgs
    {
        private string Msg { get; }
        public CustomEventArgs(string str)
        {
            Msg = str;
        }
    }

    public class Friend
    {
        public string Name { get; set; }
        public Friend(string name)
        {
            Name = name;
        }

        public void SendMsg(string msg)
        {
            Console.WriteLine(this.Name + " receive the message: " + msg);
        }
    }
}
