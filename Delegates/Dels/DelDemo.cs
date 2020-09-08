using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Dels
{
    public delegate void PrintMsgDel(object obj);
    public delegate int MathDel(int x, int y);
    public class DelDemo
    {
        public void PrintTime(object obj)
        {
            Console.WriteLine(DateTime.UtcNow.Ticks);
        }

        public int Add(int x,int y)
        {
            return x + y;
        }
    }
}
