using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ConsoleApp101
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> messageTarget;
            if(Environment.GetCommandLineArgs().Length==1)
            {
                messageTarget = delegate (string str) { ShowWindowMessage(str); };
            }
            else
            {
                messageTarget = delegate (string str) { Console.WriteLine(str); };
            }

            messageTarget("Hello World!\n");
            Console.ReadLine();
        }

        private static void ShowWindowMessage(string msg)
        {
            MessageBox.Show(msg);
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
