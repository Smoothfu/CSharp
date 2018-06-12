using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp224
{
    public delegate void JudgeHandler(Person p, PersonEventArgs e);
    public delegate void JugeRunHandler(Run runner, RunnerEventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            Run run = new Run(31, 13);
            run.JudgeRunEvent += Run_JudgeRunEvent;
            run.JudgeRunner(run);
            Console.ReadLine();
        }

        private static void Run_JudgeRunEvent(Run runner, RunnerEventArgs e)
        {
            Console.WriteLine("This is a Top-Ace runner,and its age is :{0},speed:{1},datetime is {2}", e.RunnerAge, runner.RSpeed, e.DTNow.ToString("yyyyMMMdddHHmmssFFF"));
        }

        private static void P_JudgeEvent(Person p, PersonEventArgs e)
        {
            Console.WriteLine("This is an adult,it name is {0},its age is {1},its time is {2}\n", p.PName, e.PAAge, e.DTNow.ToString("yyyyMMMdddHHmmsssFFF"));
        }
    }

    public class Person
    {
        public event JudgeHandler JudgeEvent;
        public int PAge { get; set; }
        public string PName { get; set; }
        public Person(int pAge,string pName)
        {
            PAge = pAge;
            PName = pName;
        }

        public void JudgePersonIsAdult(Person p)
        {
            if(p.PAge>18)
            {
                OnRaiseJudgeEvent();
            }
        }

        public virtual void OnRaiseJudgeEvent()
        {
            if(JudgeEvent!=null)
            {
                JudgeEvent(this, new PersonEventArgs(PAge,DateTime.Now));
            }
        }
    }

    public class PersonEventArgs:EventArgs
    {
        public int PAAge { get; set; }
        public DateTime DTNow { get; set; }
        public PersonEventArgs(int pAAge,DateTime dt)
        {
            PAAge = pAAge;
            DTNow = dt;
        }
    }

    public class Run
    {
        public event JugeRunHandler JudgeRunEvent;
        public int RAge { get; set; }
        public double RSpeed { get; set; }
        public Run(int rAge,double rSpeed )
        {
            RAge = rAge;
            RSpeed = rSpeed;
        }

        public void JudgeRunner(Run run)
        {
            if(run.RSpeed>12)
            {
                OnJudgeRunEvent();
            }
        }

        public virtual void OnJudgeRunEvent()
        {
            if(JudgeRunEvent!=null)
            {
                JudgeRunEvent(this, new RunnerEventArgs(RAge, DateTime.Now));
            }
        }

    }

    public class RunnerEventArgs:EventArgs
    {
        public int RunnerAge { get; set; }
        public DateTime DTNow { get; set; }
        public RunnerEventArgs(int runnerAge,DateTime dtNow)
        {
            RunnerAge = runnerAge;
            DTNow = dtNow;
        }
    }

}
