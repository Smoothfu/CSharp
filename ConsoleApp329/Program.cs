using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp329
{
    class Program
    {
        static void Main(string[] args)
        {
            BubbleSort();
            Console.ReadLine();
        }

        static  int SimpleHash(string s,string[] arr)
        {
            int tot = 0;
            char[] cName= s.ToCharArray();
            for(int i = 0; i <= cName.GetUpperBound(0); i++)
            {
                tot += (int)cName[i];
            }
            return tot % arr.GetUpperBound(0);
        }

        static void ShowDistrib(string[] arr)
        {
            for(int i=0;i<=arr.GetUpperBound(0);i++)
            {
                if(arr[i]!=null)
                {
                    Console.WriteLine(i + " " + arr[i]);
                }
            }
        }

        static int BetterHash(string s,string[] arr)
        {
            int tot = 0;
            char[] cname;
            cname = s.ToCharArray();
            for(int i=0; i<=cname.GetUpperBound(0);i++)
            {
                tot += 37 * tot + (int)cname[i];
            }
            tot = tot % arr.GetUpperBound(0);
            if(tot<0)
            {
                tot += arr.GetUpperBound(0);
            }
            return tot;
        }

        static void BubbleSort()
        {
            Random rnd = new Random();
            List<int> intList = new List<int>();
            for(int i=0;i<100000;i++)
            {
                intList.Add(rnd.Next(1, 100000000));
            }

            var sortedList = from i in intList
                             orderby i ascending
                             select i;
            foreach(var i in sortedList)
            {
                Console.WriteLine(i);
            }
        }
    }
}
