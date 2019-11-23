using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp392
{
    class Program
    {
        static void Main(string[] args)
        {
            EventDemo demo = new EventDemo(DateTime.Now);
            demo.DemoEvent += Demo_DemoEvent;
            demo.Dt = new DateTime(2019, 11, 23);
            Console.ReadLine();
        }

        private static void Demo_DemoEvent(object sender, DemoArgs e)
        {
            Console.WriteLine($"DemoArgs has changed,and its value is {e.DemoDT}");
        }
    }     

    public class DemoArgs
    {
        public DateTime DemoDT { get; set; }
        public DemoArgs(DateTime dt)
        {
            DemoDT = dt;
        }
    }

    public class EventDemo
    {
        public event EventHandler<DemoArgs> DemoEvent;

        private DateTime dtValue;
        public DateTime Dt
        {
            get
            {
                return dtValue;
            }
            set
            {
                if(value!=dtValue)
                {
                    dtValue = value;
                    RaisePropertyChanged(value);
                }
            }
        }

        private void RaisePropertyChanged(DateTime value)
        {
            DemoEvent?.Invoke(this, new DemoArgs(value));
        }

        public EventDemo(DateTime eventDT)
        {
            Dt = eventDT;
        }
    }

}
