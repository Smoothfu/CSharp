using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;


namespace ConsoleApp202
{
    class Program
    {
        static void Main(string[] args)
        {
            Person personObj = new Person(1,"Floomberg");
            ThreadStart ts = new ThreadStart(personObj.GetPersonInfo);
            Thread thread = new Thread(ts);
            thread.Start();
            Console.ReadLine();
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

        public void GetPersonInfo()
        {
            Console.WriteLine("PId:{0},PName:{1}\n", PId, PName);
        }
        public override string ToString()
        {
            return string.Format("PId:{0},PName:{1}\n", PId, PName);
        }
    }
}
