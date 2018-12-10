using System;
using System.Collections;

namespace ConsoleApp305
{
    class Program
    {
        static void Main(string[] args)
        {
            CQueue queue = new CQueue();
            queue.EnQueue(10);
            queue.EnQueue(10);
            queue.EnQueue(10);
            queue.EnQueue(10);
            queue.EnQueue(10);
            queue.EnQueue(10);
            queue.EnQueue(10);
            queue.EnQueue(10);

            var peekResult = queue.Peek();
            Console.WriteLine(peekResult);
            queue.DeQueue();

            int queueEleCount2 = queue.Count();
            Console.WriteLine(queueEleCount2);
            queue.ClearQueue();
            int queueEleCount = queue.Count();
            Console.WriteLine(queueEleCount);
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
