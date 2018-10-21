using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            Person pn = new Person(1, "Floomberg");
            ParameterizedThreadStart parameterizedThreadStart = new ParameterizedThreadStart(DescPerson);
            
            Thread thread = new Thread(parameterizedThreadStart);
            thread.Start(pn);
            Console.ReadLine();
        }

        static void GetCurrentTime()
        {
            Console.WriteLine("Now is {0}\n", DateTime.Now.ToString("yyyyMMddHHmmssfff"));
        }


        static void DescPerson(object obj)
        {
            var personObj = obj as Person;
            if(personObj!=null)
            {
                Console.WriteLine(personObj.ToString());
            }
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
            return string.Format("Id:{0},Name:{1}\n", PId, PName);
        } 
    }
}
