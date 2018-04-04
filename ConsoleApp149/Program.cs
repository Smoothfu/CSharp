using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp149
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));

            string filePath = dir.FullName + "\\myTxt.txt";

            FileInfo fi = new FileInfo(filePath);
            DateTime dt = DateTime.Now;
            DateTime newDt = dt.AddSeconds(1);

            using (StreamWriter sw = fi.AppendText())
            {
                while(DateTime.Now.Subtract(newDt).Seconds<0)
                {
                    string msg = "Now is: " + DateTime.Now.ToString("yyyyMMdd-hhmmssfff");
                    sw.WriteLine(msg);
                }                                
            }

            Console.ReadLine();
        }
    }
}
