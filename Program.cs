using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp313
{
    class Program
    {
        public delegate void CallHandler(string msg);
        public event CallHandler CallEvent;
        public delegate void MathDel(int x, int y);
        public event MathDel MathEvent;

        static void Main(string[] args)
        {            
            Program p = new Program();
            p.MathEvent += P_MathEvent;
            p.OnMathEvent(100, 100);
            Console.ReadLine();
        }

        private static void P_MathEvent(int x, int y)
        {
            Console.WriteLine($"This is multiply {x}*{y}={x * y}");
        }

        public void OnMathEvent(int x, int y)
        {
            if(MathEvent!=null)
            {
                MathEvent(x, y);
            }
        }
          
    }
}
