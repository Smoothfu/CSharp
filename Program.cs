using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ConsoleApp300
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = new string[10];
            names.SetValue("Fred1",0);
            names.SetValue("Fred2",1);
            names.SetValue("Fred3",2);
            names.SetValue("Fred4",3);
            names.SetValue("Fred5",4);
            names.SetValue("Fred6",5);

            if(names!=null && names.Any())
            {
                foreach(string name in names)
                {
                    Console.WriteLine(name);
                }
            }
            Console.ReadLine();
        }

        static void ArrayListSizeChangeDynamically()
        {
            ArrayList al = new ArrayList();
            al.Capacity = 5;
            Random rnd = new Random();
            for (int i = 0; i < 1000002; i++)
            {
                al.Add(rnd.Next(0, 10000002));
            }
            Console.WriteLine(al.Capacity);
        }
        static void FindPrimes(int num)
        {
            List<int> primeList = new List<int>();
            int countNum = 0;

            for(int i=2;i<=num;i++)
            {
                bool isPrime = true;
                for (int j=2;j<=Math.Sqrt(i);j++)
                {
                    ++countNum;
                    if (i%j==0)
                    {                        
                        isPrime = false;
                        break;
                    }                 
                }

               if(isPrime)
                {
                    primeList.Add(i);
                }
            }

          
            if(primeList!=null && primeList.Any())
            {
                foreach(int i in primeList)
                {
                    Console.Write(i + "\t");
                }
            }

            Console.WriteLine("\n\nThis has computed {0}  times", countNum);
        }
    }
}
