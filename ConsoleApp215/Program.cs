using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp215
{
    class Program
    {
        static void Main(string[] args)
        {
            Counter c = new Counter(10);
            c.ThresholdReached += C_ThresholdReached;

            Console.WriteLine("Press 'a' key to increase total!");
            do
            {
                c.Add(1);
            } while (c.total < 11);

            Console.ReadLine();
        }

        private static void C_ThresholdReached(object sender, ThreadsholdReachedEventArgs e)
        {
            Console.WriteLine("Threshold:{0},TimeReached:{1}\n", e.Threshold, e.TimeReached);
           
        }
    }

    class Counter
    {

        public event EventHandler<ThreadsholdReachedEventArgs> ThresholdReached;
        private int threshold;
        public int total;

        public Counter(int passedThreadshold)
        {
            threshold = passedThreadshold;
        }

        public void Add(int x)
        {
            total += x;
            if(total>=threshold)
            {
                ThreadsholdReachedEventArgs args = new ThreadsholdReachedEventArgs();
                args.Threshold = threshold;
                args.TimeReached = DateTime.Now;

                OnThresholdReached(args);
            }
        }

        protected virtual void OnThresholdReached(ThreadsholdReachedEventArgs e)
        {
            EventHandler<ThreadsholdReachedEventArgs> handler = ThresholdReached;
            if(handler!=null)
            {
                handler(this, e);
            }
        }
    }

    public class ThreadsholdReachedEventArgs:EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }
}
