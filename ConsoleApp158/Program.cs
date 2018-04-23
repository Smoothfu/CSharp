using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp158
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start a new "task" to process the ints.
            Task.Factory.StartNew(() =>
            {
                ProcessIntData();
            });

            Console.ReadLine();
        }

        static void ProcessIntData()
        {
            //Get a very large array of integers.
            int[] source = Enumerable.Range(1, 100000000).ToArray();

            //Find the numbers where num%3==0 is true,returned in descending order.
            int[] modThreeIsZero = (from num in source.AsEnumerable() where num % 3 == 0 orderby num descending select num).ToArray();
            MessageBox.Show(string.Format("Found {0} numbers that match query!\n", modThreeIsZero.Count()));
            
        }
    }
}
