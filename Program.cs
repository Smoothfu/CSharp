using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp371
{
    delegate int AddDel(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            DefaultDemo(20);
            DefaultDemo();
            Console.ReadLine();
        }

        static void DefaultDemo(int x=10)
        {
            Console.WriteLine(x);
        }
        static void NameofDemo()
        {
            int capacity = 2019;
            string x = nameof(capacity);
            Console.WriteLine(x);
        }
        static void UsingStaticDemo()
        {
            WriteLine("Be honest");
        }
        static void ExceptionFilterDemo()
        {
            string result;
            try
            {
                result = new WebClient().DownloadString("https://stackoverflow.com/questions/135443/how-do-i-use-reflection-to-invoke-a-private-method");
                Console.WriteLine(result);
            }
            catch(WebException ex) when (ex.Status==WebExceptionStatus.Timeout)
            {
                Console.WriteLine($"{ex.Message}");
            }
        }
        static void StringInterpolationDemo()
        {
            string s = $"It's {DateTime.Now.ToString("yyyyMMddHHmmssffff")} now";
            Console.WriteLine(s);
        }
        static void IndexInitializerDemo()
        {
            var dict = new Dictionary<int, string>()
            {
                [3] = "three",
                [10] = "ten"
            };
            foreach(var d in dict)
            {
                Console.WriteLine($"key:{d.Key},value:{d.Value}");
            }
        }
        public DateTime DtNow { get; } = DateTime.Now;
        public void ShowDTNow() => Console.WriteLine(DtNow);
        static void ExpressionBodyDemo() => Console.WriteLine("This is the Expression Body function!");
        static void TupleDemo()
        {
            var fred = (Name: "Fred", Age: 32, Id: 1,Rank:1,Title:"Doctor");
            Console.WriteLine(fred.Name);
            Console.WriteLine(fred.Age);
            Console.WriteLine(fred.Id);
            Console.WriteLine(fred.Rank);
            Console.WriteLine(fred.Title);
            Type type = fred.GetType();
            Console.WriteLine(type.Name); 
        }
        static void LocalMethodsDemo()
        {
            Console.WriteLine(cube(10));
            Console.WriteLine(cube(100));
            Console.WriteLine(cube(1000));
            int cube(int value) => value * value * value;
        }
        static void SwitchDemo(object x)
        {
            switch(x)
            {
                case int i:
                    Console.WriteLine("It's an int!");
                    break;
                case string str:
                    Console.WriteLine($"It's string, length is {str.Length}");
                    break;
                case bool b when b == true:
                    Console.WriteLine("True");
                    break;
                case null:
                    Console.WriteLine("Nothing!");
                    break;
            }
        }
        static void OutDemo()
        {
            if (int.TryParse("123", out int result))
            {
                Console.WriteLine(result);
            }
        }
        private static void AddCallBack(IAsyncResult ar)
        {
            Console.WriteLine(ar.AsyncState);
        }
        static int AddXY(int x,int y)
        {
            return x + y;
        }
    }

    public class Person
    {
        string name;
        public string Name
        {
            get => name;
            set => name = value ?? "";
        }
        public Person(string name) => Name = name;
        ~Person() => Console.WriteLine("Finalize");          
        
    }
}
