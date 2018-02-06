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
            List<string> nameList = new List<string>();
            nameList.Add("Fred");
            nameList.Add("Floomberg");
            nameList.Add("Michael Bloomberg");
            nameList.Add("Bill Gates");
            nameList.Add("Elon Musk");
            nameList.Add("Larry Ellison");
            nameList.Add("Mark Zuckerberg");
            nameList.Add("Larry Page");
            nameList.Add("Jeff Bezos");
            nameList.Add("Pony Ma");
            

            //Display the contents of the list using the Print method.
            nameList.ForEach(PrintName);
            Console.WriteLine("\n\n\n");
            //The following demonstrates the anonoymous method feature of C#
            //to display the contents of the list to the console.
            nameList.ForEach(delegate (string name)
            {
                Console.WriteLine(name);
            });
            Console.ReadLine();
        }

        private static void PrintName(string str)
        {
            Console.WriteLine(str);
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
