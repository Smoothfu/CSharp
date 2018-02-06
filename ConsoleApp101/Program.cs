using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp101
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student { Name = "Fred", Age = 31 };
            Action<Student, Exception> action = Display;
            action(stu, null);
            CallingAction(action);
            Console.ReadKey(true);

            action = Show;
            action(stu, null);
            CallingAction(action);
            Console.ReadLine();
        }

        static void Add(int x,int y)
        {
            for(int i=0;i<1000;i++)
            {
                Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
                Thread.Sleep(100);
                x = x + 10000;
                y = y + 10000;
            }
        }

        static void Display(Student stu,Exception ex)
        {
            Console.WriteLine("Display :{0}\n", stu.Name);
            Console.WriteLine("Display:{0}\n", stu.Age);
        }

        static void Show(Student stu,Exception ex)
        {
            Console.WriteLine("Show:{0}\n", stu.Name);
            Console.WriteLine("Show:{0}\n", stu.Age);
        }

        static void CallingAction(Action<Student,Exception> action)
        {
            Console.WriteLine(action.Method.Name.ToString()+"\n");
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
