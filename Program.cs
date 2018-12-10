using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;
using System.Text.RegularExpressions;

namespace ConsoleApp304
{
    class Program
    {
        static void Main(string[] args)
        {
            int num, baseNum;
            Console.Write("Enter a decimal number: ");
            num = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter a base: ");
            baseNum = Convert.ToInt32(Console.ReadLine());
            Console.Write(num + " converts to ");
            MulBase(num, baseNum);
            Console.WriteLine(" Base " + baseNum);
            Console.ReadLine();
        }

        private static void MulBase(int num, int baseNum)
        {
            Stack digits = new Stack();
            do
            {
                digits.Push(num % baseNum);
                num /= baseNum;
            } while (num != 0);

            while(digits.Count>0)
            {
                Console.Write(digits.Pop());
            }
        }

        static void SelectionSort(int[] arr)
        {
            if(arr==null ||!arr.Any())
            {
                return;
            }

            Console.WriteLine("Initial sort: \n" + string.Join("\t", arr) + "\n");
            for(int i=0;i<arr.Length;i++)
            {
                int minIndex = i;                
                for(int j=i+1;j<arr.Length;j++ )
                {
                    if(arr[j]<arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if(minIndex!=i)
                {
                    int temp = arr[minIndex];
                    arr[minIndex] = arr[i];
                    arr[i] = temp;
                }
            }

            Console.WriteLine("\nAfter selection sort:\n " + string.Join("\t", arr));

        }

        static int BinarySearch(int[] arr,int target)
        {
            if(arr==null || !arr.Any())
            {
                return -1;
            }

            Array.Sort(arr);
            int low = 0, high = arr.Length - 1;
            while(low<=high)
            {
                int mid = (low + high) / 2;
                if(arr[mid]==target)
                {
                    return mid + 1;
                }

                if(arr[mid]>target)
                {
                    high = mid - 1;
                }

                if(arr[mid]<target)
                {
                    low = mid + 1;
                }
            }

            return -1;
        }

        static void FindMin(int[] arr)
        {
            if(arr==null || !arr.Any())
            {
                return;
            }
            Console.WriteLine("The initial array is \n" + string.Join("\t", arr) + "\n");
            int min = arr[0];
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]<min)
                {
                    min = arr[i];
                }
            }

            Console.WriteLine("\nThe minimum element in this array is  " + min);
        }

        static void FindMax(int[]arr)
        {
            if(arr==null || !arr.Any())
            {
                return;
            }

            Console.WriteLine("The initial order: \n" + string.Join("\t", arr));
            int max = arr[0];
            for(int i=0;i<arr.Length;i++)
            {
                if(arr[i]>max)
                {
                    max = arr[i];
                }
            }

            Console.WriteLine("\nThe max in array is " + max);
        }

        static int RecursiveBinSearch(int[] arr,int target,int low,int high)
        {            
            if(arr==null ||!arr.Any())
            {
                return -1;
            }

            else
            {
                int mid;
                mid = (low + high) / 2;
                if(target>arr[mid])
                {
                    RecursiveBinSearch(arr, target,mid+1,high);
                }
                else if (target==arr[mid])
                {
                    Console.WriteLine("The target value in the arr's index is {0}\n ", mid + 1);
                    return mid;
                }
                else
                {
                    RecursiveBinSearch(arr, target,low,mid-1);
                }
            }
            return -1;
        }

        static void CheckPalindrome(string str)
        {
            if(string.IsNullOrEmpty(str))
            {
                return;
            }

            string ch;
            bool isPalindrome = true;
            int pos = 0;
            Stack<string> stringStack = new Stack<string>();
            
            for(int i=0;i<str.Length;i++)
            {
                stringStack.Push(str.Substring(i, 1));
            }

            while (stringStack.Count > 0)
            {
                ch = stringStack.Pop().ToString();
                if(ch!=str.Substring(pos,1))
                {
                    isPalindrome = false;
                    break;
                }
                pos++;
            }

            if(isPalindrome)
            {
                Console.WriteLine(str + " is a palindrome");
            }
            else
            {
                Console.WriteLine(str + " is not a palindrome");
            }                       
        }

        //IsNumeric is not built into C# so we must define it
        static bool IsNumeric(string input)
        {
            bool flag = true;
            string pattern = (@"^\d+$");
            Regex validate = new Regex(pattern);
            if(!validate.IsMatch(input))
            {
                flag = false;
            }
            return flag;
        }

        static void Calculate(Stack N,Stack O,string exp)
        {
            string ch, token = "";
            for(int p=0;p<exp.Length;p++)
            {
                ch = exp.Substring(p, 1);
                if(IsNumeric(ch))
                {
                    token += ch;
                    if(ch==" "||p==(exp.Length-1))
                    {
                        if(IsNumeric(token))
                        {
                            N.Push(token);
                            token = "";
                        }
                    }
                    else if(ch =="+" || ch =="-" || ch =="*" || ch== "/")
                    {
                        O.Push(ch);
                    }

                    if(N.Count==2)
                    {
                        Compute(N, O);
                    }
                }
            }
        }

        private static void Compute(Stack N, Stack O)
        {
            int oper1, oper2;
            string oper;
            oper1 = Convert.ToInt32(N.Pop());
            oper2 = Convert.ToInt32(N.Pop());
            oper = Convert.ToString(O.Pop());

            switch(oper)
            {
                case "+":
                    N.Push(oper1 + oper2);
                    break;
                case "-":
                    N.Push(oper1 - oper2);
                    break;
                case "*":
                    N.Push(oper1 * oper2);
                    break;
                case "/":
                    N.Push(oper1 / oper2);
                    break;
            }
        }
    }
}
