using System;
using System.Collections;

namespace ConsoleApp305
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue myQueue = new Queue(32, 3);
            for(int i=0;i<33;i++)
            {
                myQueue.Enqueue(i);
            }

            Console.WriteLine(myQueue.Count);
            Console.WriteLine();
            Console.ReadLine();
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
}
