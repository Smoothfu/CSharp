using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp153
{
    class Program
    {
        static DateTime dt = DateTime.Now;
        static DateTime dtNew = dt.AddSeconds(60);
        static int x = 1000, y = 1000;
       
        static void Main(string[] args)
        {
            Task.Run(() =>
            {
                //simulate processing.
                while (DateTime.Now.Subtract(dtNew).Seconds < 0)
                {
                    AddMethod(ref x, ref y);
                }
            }).ContinueWith(x => System.Windows.Forms.MessageBox.Show("Done!"));          
            

            Console.ReadLine();            
        }

        static void AddMethod(ref int x,ref int y)
        {
           Console.WriteLine("{0}+{1}={2}\n", x, y, x + y);
            x += 1000;
            y += 1000;
        }
    }   
}
