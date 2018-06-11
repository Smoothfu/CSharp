using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace ConsoleApp221
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree tr = CreateTree();
            InOrder(tr);
            Console.ReadLine();
        }

        static void DisplayImagesFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Users\Fred\Pictures");

            //Get all files with a *.jpg extension.
            FileInfo[] imgFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            //How many were found?
            Console.WriteLine("Found {0} *.jpg files\n", imgFiles.Length);

            //Now print out info for each file.
            foreach (FileInfo fi in imgFiles)
            {
                Console.WriteLine("************************************************");
                Console.WriteLine("File name:{0}\n", fi.Name);
                Console.WriteLine("File size:{0}\n", fi.Length);
                Console.WriteLine("Creation:{0}\n", fi.CreationTime);
                Console.WriteLine("Attributes:{0}\n", fi.Attributes);
                Console.WriteLine("**************************************************\n"); }
        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");

            //Create \myFolder off application directory.
            dir.CreateSubdirectory("mySub");

            DirectoryInfo[] dirs = dir.GetDirectories("*", SearchOption.AllDirectories);
            if (dirs != null && dirs.Any())
            {
                Console.WriteLine("There are {0} directories in the path\n\n\n", dirs.Length);
                dirs.All(x =>
                {
                    Console.WriteLine("{0},{1}", x.FullName, x.CreationTime);
                    return true;
                });
            }
        }

        static void FunWithDirectoryType()
        {
            //List all drives on current computer.
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your drives:\n");

            drives.All(x =>
                {
                    Console.WriteLine(x);
                    return true;
                });

            //Delete what was created.
            Console.WriteLine("Press Enter to delete directories\n");
            Console.ReadLine();
            try
            {


                //The second parameter specifies whether you wish to destory any subdirectories.
                Directory.Delete(@"D:\C\ConsoleApp221\ConsoleApp221\bin\Debug\sub", true);
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void InitQueue()
        {
            //Creates and initializes a new queue.
            Queue mq = new Queue();
            mq.Enqueue("The world is fair");
            mq.Enqueue("Everything depend on myself");
            mq.Enqueue("Make every second count");

            //Displays the properties and values of the Queue.
            Console.WriteLine("mq:");
            Console.WriteLine("Count:{0}", mq.Count);
            Console.WriteLine("Values:");

            while(mq.Count>0)
            {
                Console.WriteLine(mq.Dequeue());
            }


            Console.ReadLine();
        } 

        static void InitStack()
        {
            Stack stk = new Stack();
            stk.Push("The world is fair");
            stk.Push("Everything depend on myself");
            stk.Push("Make every second count!");

            while(stk.Count>0)
            {
                Console.WriteLine(stk.Pop());
            }
        }

        public static Tree CreateTree()
        {
            Tree tree = new Tree() { Value = "A" };
            tree.Left = new Tree()
            {
                Value = "B",
                Left = new Tree() { Value = "D", Left = new Tree() { Value = "G" } },
                Right = new Tree() { Value = "E", Left = new Tree() { Value = "B" } }
            };

            tree.Right = new Tree() { Value = "C", Right = new Tree() { Value = "F" } };

            return tree;
        }

        public static void PreOrder(Tree tree)
        {
            if(tree==null)
            {
                return;
            }

            System.Console.WriteLine(tree.Value);
            PreOrder(tree.Left);
            PreOrder(tree.Right);
        }

        public static void PreOrderNoRecursion(Tree tree)
        {
            if(tree==null)
            {
                return;
            }

            System.Collections.Generic.Stack<Tree> stk = new Stack<Tree>();

            Tree node = tree;
            while(node!=null || stk.Any())
            {
                if(node!=null)
                {
                    stk.Push(node);
                    Console.WriteLine(node.Value);
                    node = node.Left;
                }
                else
                {
                    var item = stk.Pop();
                    node = item.Right;
                }
            }
        }

        public static void InOrder(Tree tree)
        {
            if(tree==null)
            {
                return;
            }
            InOrder(tree.Left);
            Console.WriteLine(tree.Value);
            InOrder(tree.Right);
        }
    }

    [DebuggerDisplay("Value=(Value)")]
    public class Tree
    {
        public string Value;
        public Tree Left;
        public Tree Right;
    }
}
