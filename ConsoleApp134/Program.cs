using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp134
{
    class Program
    {
        static void Main(string[] args)
        {
            //Return a value type with a lambda expression.
            Task<int> task1 = Task<int>.Factory.StartNew(() => 1);

            int i = task1.Result;

            Console.WriteLine("task1.Result：{0}\n",i);
            //Return a named reference type with a multi-line statement lambda.
            Task<Test> task2 = Task<Test>.Factory.StartNew(() =>
            {
                string s = ".NET";
                double d = 4.0;
                return new Test { Name = s, Number = d };
            });

            Console.WriteLine("\n\n\ntask2.Result:\n");
            Test test = task2.Result;
            Console.WriteLine(test);


            //Return an array produced by a PLINQ query.
            Task<string[]> task3 = Task<string[]>.Factory.StartNew(() =>
            {

                string path = @"C:\Users\Fred\Pictures\";
                string[] files = System.IO.Directory.GetFiles(path);

                var result = (from file in files.AsParallel()
                              let info = new System.IO.FileInfo(file)
                              where info.Extension == ".jpg"
                              select file).ToArray();
                return result;
            });

            Console.WriteLine("\n\n\n task3 result:\n");
            foreach(var name in task3.Result)
            {
                Console.WriteLine(name);
            }
            Console.ReadLine();
        }

        private static Double DoComputation(Double start)
        {
            Double sum = 0;
            for(var value=start;value<=start+10;value+=10.0)
            {
                sum += value;
            }
            return sum;
        }
    }

    class Test
    {
        public string Name { get; set; }
        public double Number { get; set; }


        public override string ToString()
        {
            return string.Format("Name:{0},Number:{1}\n", Name, Number);
        }
    }
}
