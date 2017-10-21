using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace ConsoleApp80
{
    class Program
    {
        static FileStream fs;
        static StreamWriter sw;

        //委托声明
        public delegate void printWord(string str);

        //该方法打印到控制台
        public static void WriteToScreen(string str)
        {
            Console.WriteLine("The string is :{0}", str);
        }

        //该方法打印到文件
        public static void WriteToFile(string str)
        {
            string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            fs = new FileStream(fileName + "\\message.txt",FileMode.Append,FileAccess.Write);
            sw = new StreamWriter(fs);
            sw.WriteLine(str);
            sw.Flush();
            sw.Close();
            fs.Close();
        }

        //该方法把委托作为参数，并使用它调用方法
        public static void SendString(printWord str)
        {
            str("This is delegate!");
        }
        static void Main(string[] args)
        {
            printWord pw1 = new printWord(WriteToScreen);
            printWord pw2 = new printWord(WriteToFile);
            SendString(pw1);
            SendString(pw2);
            
            Console.ReadLine();
        }
    }
}
