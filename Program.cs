using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp305
{
    class Program
    {    
        static void Main(string[] args)
        {
            FindPrimes(1000);
            Console.ReadLine();
        }

        static void FindPrimes(int num)
        {
            List<int> primeList = new List<int>();
            for(int i=2;i<=num;i++)
            {
                bool isPrime = true;
                for(int j=2;j<=Math.Sqrt(i);j++)
                {
                    if(i%j==0)
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

            Console.WriteLine("The totally primes below " + num + "\n");
            Console.WriteLine(string.Join("\t", primeList));
        }
        enum DigitType { ones = 1, tens = 10 }
        static void DisplayArray(int[] arr)
        {
            for (int x = 0; x < arr.GetUpperBound(0); x++)
            {
                Console.Write(arr[x] + " ");
            }
        }

        static void RSort(Queue[] que,int[] arr,DigitType digit)
        {
            int snum;
            for(int x=0;x<=arr.GetUpperBound(0);x++)
            {
                if(digit==DigitType.ones)
                {
                    snum = arr[x] % 10;
                }
                else
                {
                    snum = arr[x] / 10;
                }

                que[snum].Enqueue(arr[x]);
            }
        }

        static void BuildArray(Queue[] queue,int [] arr)
        {
            int j = 0;
            for(int i=0;i<=9;i++)
            {
                while(queue[i].Count>0)
                {
                    arr[j] = Int32.Parse(queue[i].Dequeue().ToString());
                    j++;
                }
            }
        }
        static void newDancers(Queue male, Queue female)
        {
            Dancer m, w;
            m = new Dancer();
            w = new Dancer();
            if (male.Count > 0 && female.Count > 0)
            {
                m.GetName(male.Dequeue().ToString());
                w.GetName(female.Dequeue().ToString());
            }

            else if ((male.Count > 0) && (female.Count == 0))
            {
                Console.WriteLine("Waitting on a female dancer.");
            }
            else if ((female.Count > 0) && (male.Count == 0))
            {
                Console.WriteLine("Waiting on a male dancer.");
            }
        }

        static void HeadOfLine(Queue male, Queue female)
        {
            Dancer w, m;
            m = new Dancer();
            w = new Dancer();
            if (male.Count > 0)
            {
                m.GetName(male.Peek().ToString());
            }

            if (female.Count > 0)
            {
                w.GetName(female.Peek().ToString());
            }

            if (m.name != " " && w.name != " ")
            {
                Console.WriteLine("Next in the line are: " + m.name + "\t" + w.name);
            }
            else
            {
                if (m.name != " ")
                {
                    Console.WriteLine("Next in line is :" + m.name);
                }

                else
                {
                    Console.WriteLine("Next in line is: " + w.name);
                }
            }
        }

        static void StartDancing(Queue male, Queue female)
        {
            Dancer m, w;
            m = new Dancer();
            w = new Dancer();
            Console.WriteLine("Dance partners are: ");
            Console.WriteLine();

            for (int count = 0; count <= 3; count++)
            {
                m.GetName(male.Dequeue().ToString());
                w.GetName(female.Dequeue().ToString());
                Console.WriteLine(w.name + "\t" + m.name);
            }
        }

        static void FormLines(Queue male, Queue female)
        {
            Dancer d = new Dancer();
            StreamReader inFile;
            inFile = File.OpenText(".\\bat.dat");
            string line;
            while (inFile.Peek() != -1)
            {
                line = inFile.ReadLine();
                d.sex = line.Substring(0, 1);
                d.name = line.Substring(2, line.Length - 2);
                if (d.sex == "M")
                {
                    male.Enqueue(d);
                }
                else
                {
                    female.Enqueue(d);
                }
            }
        }

    }

    public class CQueue
    {
        private ArrayList pqueue;
        public CQueue()
        {
            pqueue = new ArrayList();
        }

        public void EnQueue(object item)
        {
            pqueue.Add(item);
        }
        
        public void DeQueue()
        {
            pqueue.RemoveAt(0);
        }

        public object Peek()
        {
            return pqueue[0];
        }

        public void ClearQueue()
        {
            pqueue.Clear();
        }

        public int Count()
        {
            return pqueue.Count;
        }
    }

    public struct Dancer
    {
        public string name;
        public string sex;
        public void GetName(string n)
        {
            name = n;
        }

        public override string ToString()
        {
            return name;
        }

       
    }

    public struct PQItem
    {
        public int priority;
        public string name;
    }

    public class PQueue : Queue
    {       

        public override object Dequeue()
        {
            object[] items;
            int  min, minIndex=0;
            items = this.ToArray();
            min = ((PQItem)items[0]).priority;
            for(int i=1;i<=items.GetUpperBound(0);i++)
            {
                if(((PQItem)items[i]).priority<min)
                {
                    min = ((PQItem)items[i]).priority;
                    minIndex = i;
                }
            }

            this.Clear();

            for(int i=0;i<=items.GetUpperBound(0);i++)
            {
                if(i!=minIndex && ((PQItem)items[i]).name!=" ")
                {
                    this.Enqueue(items[i]);
                }               
            }

            return items[minIndex];
        }
    }
}
