using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;


namespace ConsoleApp222
{
    public delegate void TemperatureEventHandler(object sender, TemperatureEventArgs e);
    class Program
    {   
        static void Main(string[] args)
        {
            Counter c = new Counter(new Random().Next(10));
            c.ThresholdReached += C_ThresholdReached;
            Console.WriteLine("press 'a' key to increase total!\n");
            while (Console.ReadKey(true).KeyChar == 'a')
            {
                Console.WriteLine("adding one!\n");
                c.Add(1);
            }
            Console.ReadLine();
        }

        private static void C_ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            Console.WriteLine("The threshold of {0} was reached at {1}.\n", e.Threshold, e.TimeReached);
       
        }

        public void MonitorTemperature()
        {
            TemperatureMonitor tempMon = new TemperatureMonitor(32);
            tempMon.SetTemperature(33);
            Console.WriteLine("Current temperature is {0} degrees Fahreheit.\n", tempMon.GetTemperature());
            tempMon.SetTemperature(32);
            Console.WriteLine("Current temperature is {0} degress Fahrenheit.\n", tempMon.GetTemperature());

            //Add event handler dynamically using C# syntax.
            tempMon.TemperatureThresholdEvent += this.TempMonitor;

            tempMon.SetTemperature(33);
            Console.WriteLine("Current temperature is {0} degrees Fahrenheit.\n", tempMon.GetTemperature());
            tempMon.SetTemperature(34);
            Console.WriteLine("Curremt temperature is {0} degrees Fahrenheit.\n", tempMon.GetTemperature());
            tempMon.SetTemperature(32);
            Console.WriteLine("Current temperature is {0} degrees Fahrenheit.\n", tempMon.GetTemperature());

            //Remove event handler dynamically using c# syntax.
            tempMon.TemperatureThresholdEvent -= this.TempMonitor;

            tempMon.SetTemperature(31);
            Console.WriteLine("Current temperature is {0} degrees Fahrenheit.\n", tempMon.GetTemperature());

            tempMon.SetTemperature(35);
            Console.WriteLine("Current temperature is {0} degress Fahrenheit.\n", tempMon.GetTemperature());
        }

        private void TempMonitor(object sender,TemperatureEventArgs e)
        {
            Console.WriteLine("***The event has occured!Warning:Temperature is changing from {0} to {1}***\n", e.OldTemperature, e.NewTemperature);
        }
    }

    public class Person
    {
        public int PId { get; set; }
        public string PName { get; set; }

        public Person(int pId,string pName)
        {
            PId = pId;
            PName = pName;
        }

        public override string ToString()
        {
            return string.Format("PId:{0},PName:{1}\n", PId, PName);
        }
    }

    public class TemperatureEventArgs:EventArgs
    {
        private decimal oldTemp;
        private decimal newTemp;

        public decimal OldTemperature
        {
            get
            {
                return this.oldTemp;
            }
        }

        public decimal NewTemperature
        {
            get
            {
                return this.newTemp;
            }
        }

        public TemperatureEventArgs(decimal oldTemp,decimal newTemp)
        {
            this.oldTemp = oldTemp;
            this.newTemp = newTemp;
        }
     
    }

    public class TemperatureMonitor
    {
        private decimal currentTemperature;
        private decimal threshholdTemperature;

        public event TemperatureEventHandler TemperatureThresholdEvent;
        public event EventHandler myEvent;

        public TemperatureMonitor(decimal threshHold)
        {
            this.threshholdTemperature = threshHold;
        }

        public void SetTemperature(decimal newTemperature)
        {
            if((this.currentTemperature>this.threshholdTemperature && newTemperature<=this.threshholdTemperature) ||
                (this.currentTemperature<this.threshholdTemperature && newTemperature>=this.threshholdTemperature))
            {
                OnRaiseTemperatureEvent(newTemperature);
            };
            this.currentTemperature = newTemperature;
        }

        public decimal GetTemperature()
        {
            return this.currentTemperature;
        }

        protected virtual void OnRaiseTemperatureEvent(decimal newTemplate)
        {
            //Raise the event if it has subscribers.
            if(TemperatureThresholdEvent!=null)
            {
                TemperatureThresholdEvent(this, new TemperatureEventArgs(this.currentTemperature, newTemplate));
            }
        }
    }

    public class ThresholdReachedEventArgs:EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    class Counter
    {
        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
        private int threshold;
        private int total;

        public Counter(int passedThreadshold)
        {
            threshold = passedThreadshold;
        }

        public void Add(int x)
        {
            total += x;
            if(total>=threshold)
            {
                ThresholdReachedEventArgs args = new ThresholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;
                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
        {
            EventHandler<ThresholdReachedEventArgs> handler = ThresholdReached;
            if(handler!=null)
            {
                handler(this, e);
            }
        }
    }
}
