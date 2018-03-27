using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace ConsoleApp146
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));             
            
            string fullPath = dir.FullName + DateTime.Now.ToString("yyyyMMddHHmmssfff") + "2.txt";
            FileInfo fi = new FileInfo(fullPath);

            DateTime dtNow = DateTime.Now;
            DateTime dtNew = dtNow.AddSeconds(10);

            while(DateTime.Now.Subtract(dtNew).Seconds<0)
            {
                string msg = "Now is " + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                File.AppendAllText(fullPath, msg + Environment.NewLine);
            }

            Console.ReadLine();           
        }
    }
}
