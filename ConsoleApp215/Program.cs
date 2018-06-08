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
            Person p = new Person(10);
            p.PersonMaxAgeReached += P_PersonMaxAgeReached;
            do
            {
                p.AddAge(1);
            } while (p.PAge < 101);

            //Counter c = new Counter(10);
            //c.ThresholdReached += C_ThresholdReached;

            //Console.WriteLine("Press 'a' key to increase total!");
            //do
            //{
            //    c.Add(1);
            //} while (c.total < 11);

            Console.ReadLine();
        }

        private static void P_PersonMaxAgeReached(object sender, PersonArgs e)
        {
            Console.WriteLine("MaxAge:{0},NowTime:{1}\n", e.MaxAge, e.NowTime);
        }

        //private static void C_ThresholdReached(object sender, ThreadsholdReachedEventArgs e)
        //{
        //    Console.WriteLine("Threshold:{0},TimeReached:{1}\n", e.Threshold, e.TimeReached);
           
        //}
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
            ThresholdReached(this, e);
        }
    }

    public class ThreadsholdReachedEventArgs:EventArgs
    {
        public int Threshold { get; set; }
        public DateTime TimeReached { get; set; }
    }

    public class Person
    {
        public event EventHandler<PersonArgs> PersonMaxAgeReached;
        public int PAge { get; set; }
        public int MAge = 100;

        public Person(int pAge)
        {
            PAge = pAge;
        }

        protected virtual void OnPersonMaxAgeReached(object sender,PersonArgs e)
        {
            PersonMaxAgeReached(this, e);
        }

        public void AddAge(int i)
        {
            PAge += 10 * i;
            if(PAge>MAge)
            {
                PersonArgs pa = new PersonArgs();
                pa.MaxAge = MAge;
                pa.NowTime = DateTime.Now;
                OnPersonMaxAgeReached(this,pa);
            }
        }

    }

    public class PersonArgs:EventArgs
    {
        public int MaxAge { get; set; }
        public DateTime NowTime { get; set; }
    }
}
