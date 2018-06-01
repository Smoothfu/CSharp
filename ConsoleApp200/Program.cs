using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp200
{
    class Program
    {
        static int x = 36245645, y = 3453454;
        static void Main(string[] args)
        {
            Person p = new Person(1, "Floomberg");
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(p.OutputPerson);
            Thread newThread = new Thread(parameterizedThreadStart);
            newThread.Start(p);
            Console.WriteLine("State {0}\n", newThread.ThreadState);

            Console.ReadLine();
        }

        static void AddMethod(int x,int y)
        {
            Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
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

        public void OutputPerson(object obj)
        {
            var p = obj as Person;
            if(p!=null)
            {
                Console.WriteLine("PId:{0},PName:{1}\n", p.PId, p.PName);
            }            
        }
        public override string ToString()
        {
            return string.Format("PId:{0},PName:{1}\n", PId, PName);
        }
    }
}
