using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp223
{
    public delegate void JudgeHandler(AdultPerson p,PersonEventArgs e);
    public delegate void JudgeRichHandler(RichPerson rp, RichEventArgs e);
    class Program
    {        
        static void Main(string[] args)
        {
            RichPerson rp = new RichPerson(31, 4236245634756);
            rp.JudgeRichEvent += Rp_JudgeRichEvent;
            rp.JudgeRichPerson(rp);

            Console.ReadLine();
        }

        private static void Rp_JudgeRichEvent(RichPerson rp, RichEventArgs e)
        {
            Console.WriteLine("RichPerson's age :{0},money:{1},time is:{2}", e.RP.PAge, e.RP.PMoney,e.DT.ToString("yyyyMMddHHmmssfff"));
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

    public class RichPerson
    {
        public event JudgeRichHandler JudgeRichEvent;
        public int PAge { get; set; }
        public decimal PMoney { get; set; }

        public RichPerson(int pAge,decimal pMoney)
        {
            PAge = pAge;
            PMoney = pMoney;            
        }

        public void JudgeRichPerson(RichPerson rp)
        {
            if(rp.PMoney>10000000000)
            {
                OnJudgeRichEvent(rp);
            }
        }
        public override string ToString()
        {
            return string.Format("Its age is {0},money is {1}\n", PAge, PMoney);
        }

        public virtual void OnJudgeRichEvent(RichPerson p)
        {
            if (JudgeRichEvent != null)
            {
                JudgeRichEvent(this, new RichEventArgs(p, DateTime.Now));
            }
        }


    }

    public class  RichEventArgs:EventArgs
    {
       public RichPerson RP { get; set; }
       public   DateTime DT { get; set; }
        public RichEventArgs(RichPerson rp,DateTime dt)
        {
            RP = rp;
            DT = dt;
        }
    }
}
