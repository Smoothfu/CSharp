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
            Program obj = new Program();
            obj.MonitorTemperature();

            Console.ReadLine();
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
}
