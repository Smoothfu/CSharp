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
            IService service = new EmailService("Email");
            new Thread(new ParameterizedThreadStart(RunBackgroundService)).Start(service);


         
                
                Console.ReadLine();
        }

        static void RunBackgroundService(object service)
        {
            ((IService)service).Execute();
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
         
        static void ExecuteLongRunningOperation(object milliseconds)
        {
            Thread.Sleep((int)milliseconds);
            Console.WriteLine("Operation completed successfully!\n");
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

    public interface IService
    {
        string Name { get; set; }
        void Execute();
    }

    public class EmailService : IService
    {
        public string Name { get ; set ; }

        public void Execute()
        {
            Console.WriteLine("The Name is {0} \n.", Name);
        }

        public EmailService(string name)
        {
            this.Name = name;
        }
    }
}
