using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates.Dels
{
    public delegate void PrintMsgDel(object obj);
    public class DelDemo
    {
        public void PrintTime(object obj)
        {
            Console.WriteLine(DateTime.UtcNow.Ticks);
        }
    }
}
