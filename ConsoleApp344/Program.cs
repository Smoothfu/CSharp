using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp344
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[99];
            string name;
            string[] someNames = new string[]
            {
                "David","Jennifer","Donnie","Mayo","Raymond","Bernica","Mike","Clayton","Beata","Michael"
            };
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

        static int SimpleHash(string str,string[] arr)
        {
            int tot = 0;
            char[] cName;
            cName = str.ToCharArray();
            for(int i=0;i<cName.Length;i++)
            {
                tot += (int)cName[i];
            }
            return tot % arr.Length;
        }

        static void ShowDistrib(string[] arr)
        {
            for(int i=0;i<arr.Length;i++)
            {
                if(null!=arr[i])
                {
                    Console.WriteLine(i + "\t" + arr[i]);
                }
            }
        }
    }
}
