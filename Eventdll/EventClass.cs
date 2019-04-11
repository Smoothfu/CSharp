using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventdll
{
    public class EventClass
    {
    }

    public class SampleEventArgs
    {
        public string Text { get; }
        public SampleEventArgs(string s)
        {
            Text = s;
        }
    }

    public class Publisher
    {
        //declare the delegate
        public delegate void SampleEventHandler(object sender, SampleEventArgs e);

        //declare the event.
        public event SampleEventHandler SampleEvent;

        //Wrap the event in a protected virtual method to enable derived classes to raise the event.
        public virtual void RaiseSampleEvent()
        {
            //Raise the event by using the () operator
            if(SampleEvent!=null)
            {
                SampleEvent(this, new SampleEventArgs("Hello"));
            }
        }
    }
}
