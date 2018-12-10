using System;
using System.Collections;
using System.IO;

namespace ConsoleApp305
{
    class Program
    {    
        static void Main(string[] args)
        {
            Queue[] numQueue = new Queue[10];
            int[] nums = new int[] { 91, 46, 85, 15, 92, 35, 31, 22 };
            int[] random = new int[99];
            //display original list
            for(int i=0;i<10;i++)
            {
                numQueue[i] = new Queue();
            }

            RSort(numQueue, nums, DigitType.ones);

            //numQueue,nums,1
            BuildArray(numQueue, nums);
            Console.WriteLine("\nFirst pass results:");
            DisplayArray(nums);

            //Second pass sort.
            RSort(numQueue, nums, DigitType.tens);
            BuildArray(numQueue, nums);
            Console.WriteLine("\nSecond pass results:");
            //display final results
            DisplayArray(nums);
            Console.ReadLine();
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
}
