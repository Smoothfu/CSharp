using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace ConsoleApp353
{
    class Program
    {        
        
        static object[] objArr = new object[] { };
        static int intArrayListIndex = 0;
        static int upperCharArrayListIndex = 1;
        static int lowerCharArrayListIndex = 2;
        static void Main(string[] args)
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5 };
            List<Char> upperList = new List<char> { 'A', 'B', 'C', 'D', 'E' };
            List<char> lowerList = new List<char> { 'a', 'b', 'c', 'd', 'e' };

            int totalSize = intList.Count + upperList.Count + lowerList.Count;
            Array.Resize(ref objArr, totalSize); 
            Thread printNumbersThread = new Thread(() =>
              {
                  foreach(int i in intList)
                  {
                      PrintNumbers(i);
                  }                  
              });
            printNumbersThread.Start();

            Thread printUpperLettersThread = new Thread(() =>
              {
                  foreach (Char upperCh in upperList)
                  {
                      PrintUpperLetters(upperCh);
                  }
              });

            printUpperLettersThread.Start();

            Thread printLowerLettersThread = new Thread(() =>
              {
                  foreach (char lowerCh in lowerList)
                  {
                      PrintLowerLetters(lowerCh);
                  }
              });
            printLowerLettersThread.Start();

            if(objArr!=null && objArr.Any())
            {
                foreach(var obj in objArr)
                {
                    Console.Write(obj);
                }
            }

            Console.ReadLine();
        }
        static void PrintNumbers(int i)
        {
            objArr[intArrayListIndex] = i;             
            intArrayListIndex += 3;
        }

        static void PrintUpperLetters(char upperCh)
        {
            objArr[upperCharArrayListIndex] = upperCh;
            upperCharArrayListIndex += 3;
        }

        static void PrintLowerLetters(char lowerCh)
        {
            objArr[lowerCharArrayListIndex] = lowerCh;
            lowerCharArrayListIndex += 3;
        }
    }
}
