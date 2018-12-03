using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleApp298
{
    class Program
    {
        static void Main(string[] args)
        {
            //host name
            string hostName = Dns.GetHostName();
            Console.WriteLine("The host name is {0}\n", hostName);

            //local ip addresses
            IPHostEntry  ipEntry = Dns.GetHostEntry(hostName);
            IPAddress[] addresses = ipEntry.AddressList;

            Parallel.ForEach(addresses, x =>
            {
                Console.WriteLine("IP address is {0}", x.ToString());
                Console.WriteLine("Address Type:[{0}]", x.AddressFamily.ToString());
                Console.WriteLine();
            });
           

            Console.ReadLine();
        }

        static void HashCode()
        {

            Random rnd = new Random();
            for (int i = 0; i <= 9; i++)
            {
                int rndNum = rnd.Next(Int32.MinValue, Int32.MaxValue);
                Number n = new Number(rndNum);
                Console.WriteLine("n={0,12},hash code={1,12}", n, n.GetHashCode());
            }
        }
        
    }

    public struct Number
    {
        private int n;
        public Number(int value)
        {
            n = value;
        }

        public int Value
        {
            get
            {
                return n;
            }
        }

        public override bool Equals(object obj)
        {
            if(obj==null ||!(obj is Number))
            {
                return false;
            }
            else
            {
                return n == ((Number)obj).n;
            }
        }

        public override int GetHashCode()
        {
            return n;
        }

        public override string ToString()
        {
            return n.ToString();
        }
    }
}
