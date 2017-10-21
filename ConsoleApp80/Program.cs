using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp80
{
    class Program
    {
        static public int size = 10;
        private string[] nameList = new string[size];
        public Program()
        {
            for(int i=0;i<size;i++)
            {
                nameList[i] = "N.A";
            }
        }

        public string this[int index]
        {
            get
            {
                string tmp;

                if(index>=0 && index < size - 1)
                {
                    tmp = nameList[index];
                }
                else
                {
                    tmp = "";
                }
                return tmp;
            }
            set
            {
                if(index>=0 && index < size - 1)
                {
                    nameList[index] = value;
                }
            }
        }
        static void Main(string[] args)
        {
            Program names = new Program();
            names[0] = "Zara";
            names[1] = "ST";
            names[2] = "ZTT";
            names[3] = "LY";
            names[4] = "HT";
            names[5] = "ZDJALD";
            names[6] = "SD";

            for(int i=0;i<Program.size;i++)
            {
                Console.WriteLine(names[i]);
            }
            Console.ReadLine();
        }
    }
}
