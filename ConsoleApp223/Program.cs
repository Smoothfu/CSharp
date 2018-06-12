using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp223
{
    public delegate void JudgeHandler(AdultPerson p,PersonEventArgs e);
    class Program
    {
        
        static void Main(string[] args)
        {
            AdultPerson p = new AdultPerson(31, 1);
            p.JudgeEvent += P_JudgeEvent1;
            p.JudgeAdultPerson(p);
             
            Console.ReadLine();
        }

        private static void P_JudgeEvent1(AdultPerson p, PersonEventArgs e)
        {
            Console.WriteLine("This is an adult person,and its age is {0} and now is {1}", e.PAge,e.Dt);
        }
        
    }

    public class AdultPerson
    {
        public event JudgeHandler JudgeEvent;
        public int PAge { get; set; }
        public int PId { get; set; }

        public AdultPerson(int pAge,int pId)
        {
            PAge = pAge;
            PId = pId;
        }

        public void JudgeAdultPerson(AdultPerson p)
        {
            if(p!=null && p.PAge>18)
            {
                OnJudgeAdult(p.PAge);
            }
        }

        public override string ToString()
        {
            return string.Format("PAge:{0},PId:{1}", PAge, PId);
        }


        public virtual void OnJudgeAdult(int page )
        {
            if(JudgeEvent!=null)
            {
                JudgeEvent(this, new PersonEventArgs(page,DateTime.Now));
            }

        }

    }
    public class PersonEventArgs:EventArgs
    {
        public int PAge { get; set; } 
        public DateTime Dt { get; set; }

        public PersonEventArgs(int pAge,DateTime dt)
        {
            PAge = pAge;
            Dt = dt;
        }
         
    }
}
