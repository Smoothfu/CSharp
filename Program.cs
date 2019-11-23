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
            Adult adult = new Adult(18);
            adult.AdultEvent += Adult_AdultEvent;
            adult.Age = 20;
            Console.ReadLine();
        }

        private static void Adult_AdultEvent(object sender, AdultArgs e)
        {
            string msg = string.Empty;
            int newAge = e.AdultAge;
            if(newAge>=18)
            {
                msg = "Adult";
            }
            else
            {
                msg = "Adolescent";
            }
            Console.WriteLine($"The newly updated age is {newAge} and it's {msg} ");
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

    public class AdultArgs
    {
        public int AdultAge { get; set; }
        public AdultArgs(int age)
        {
            AdultAge = age;
        }
    }

    public class Adult
    {
        public event EventHandler<AdultArgs> AdultEvent;

        public Adult(int adultAge)
        {
            Age = adultAge;
        }

        private int ageValue;
        public int Age
        {
            get
            {
                return ageValue;
            }
            set
            {
                if(value!=ageValue)
                {
                    ageValue = value;
                    RaisePropertyChanged(value);
                }
            }
        }

        private void RaisePropertyChanged(int value)
        {
            AdultEvent?.Invoke(this, new AdultArgs(value));
        }
    }

}
