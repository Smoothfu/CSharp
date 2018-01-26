using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Drawing;

namespace ConsoleApp93
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessImages();
            Console.ReadLine();
        }

        static void PrintTime(object state)
        {
            Console.WriteLine("Time is :{0}\n", DateTime.Now.ToLongTimeString());
        }

        static void PrintTheNumbers(object state)
        {
            Printer task = state as Printer;
            if(task!=null)
            {
                task.PrintNumbers();
            }           
        }

        private static void ProcessImages()
        {
            //Load up all *.jpg files,and make a few folder for the modified data.
            string path = @"C:\Users\Default\Pictures";
            string[] allFiles = Directory.GetFiles(path,"*.jpg",SearchOption.AllDirectories);
            string newDir = @"C:\Users\Default\Pictures\NewImages";
            Directory.CreateDirectory(newDir);

            ////Process the image data in a blocking manner.
            
            //foreach(string perFile in allFiles)
            //{
            //    string fileName = Path.GetFileName(perFile);

            //    using (Bitmap bitMap = new Bitmap(perFile))
            //    {
            //        bitMap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            //        bitMap.Save(Path.Combine(newDir, fileName));

            //        //Print out the ID of the thread processing in the current image.
            //        string threadMsg = string.Format("Processing {0} on thread {1}\n", fileName, Thread.CurrentThread.ManagedThreadId);
            //        Console.WriteLine(threadMsg);
            //    }
            //}

            //Process the image data in a parallel manner!
            Parallel.ForEach(allFiles, x =>
            {
                string fileName = Path.GetFileName(x);
                string fullName = Path.GetFullPath(x);
                Console.WriteLine(fullName);

                //using (Bitmap bitMap = new Bitmap(x))
                //{
                //    bitMap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                //    bitMap.Save(Path.Combine(newDir, fileName));

                //    //Print out the ID of the thread processing in the current image.
                //    //string threadMsg = string.Format("Processing {0} on thread {1}\n", fileName, Thread.CurrentThread.ManagedThreadId);
                //    //Console.WriteLine(threadMsg);
                //}
            });
        }
    }

    public class Printer
    {
        public void PrintNumbers()
        {
            for(int i=0;i<100000;i++)
            {
                Console.WriteLine(i);
            }
        }
    }

    
}
