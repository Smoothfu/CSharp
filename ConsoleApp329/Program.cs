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
            string[] names = new string[99];
            string name;
            string[] someNames = new string[] {"David","Jennifer","Donnie","Mayo","Raymond",
            "Bernica","Mike","Clayton","Beata","Michael"};

            int hashVal;
            for(int i=0;i<10;i++)
            {
                name = someNames[i];
                hashVal = SimpleHash(name, names);
                names[hashVal] = name;
            }
            ShowDistrib(names);
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
    }
}
